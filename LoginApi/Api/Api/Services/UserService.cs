namespace Api.Services;
using Api.Models;
using BCrypt.Net;
using AutoMapper;
using Api.Authorization;
using Api.Models.Dtos;
using System.Net;
using System.Web.Http;
using Api.Helpers;

public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        Customer GetById(int id);
        void Register(RegisterRequest model);

}
    public class UserService : IUserService
    {
    private LoginContext _context;
    private IJwtUtils _jwtUtils;
    private IMapper _mapper;

    public UserService(
       LoginContext context,
       IJwtUtils jwtUtils,
       IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;


    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
        var customer =_context.Customers.SingleOrDefault(x => x.Username == model.Username);

        // validate
        
            if (customer == null || !BCrypt.Verify(model.Password, customer.Password))
            {
                throw UnauthorizedException.Unauthorized;
            }
        
        var response = _mapper.Map<AuthenticateResponse>(customer);
        response.Token = _jwtUtils.GenerateToken(customer);
        return response;
        }

        public Customer GetById(int id)
        {
        return getCustomer(id);
        }

    public void Register(RegisterRequest model)
    {
        if (_context.Customers.Any(x => x.Username == model.Username))
            throw new Exception("Username '" + model.Username + "' is already taken");

        // map model to new customer object
        var customer = _mapper.Map<Customer>(model);

        // hash password
        customer.Password = BCrypt.HashPassword(model.Password);

        // save customer
        _context.Customers.Add(customer);
        _context.SaveChanges();
    }

    

    private Customer getCustomer(int id)
    {
        var user = _context.Customers.Find(id);
        if (user == null) throw new Exception("User not found");
        return user;
    }
}

