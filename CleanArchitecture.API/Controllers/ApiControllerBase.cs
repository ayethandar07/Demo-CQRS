using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public abstract class ApiControllerBase : ControllerBase
{
    public ISender _mediator;

    protected ISender Mediator => _mediator ?? HttpContext.RequestServices.GetRequiredService<ISender>();
}
