using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MobyLabWebProgramming.Core.DataTransferObjects;
using MobyLabWebProgramming.Core.Requests;
using MobyLabWebProgramming.Core.Responses;
using MobyLabWebProgramming.Infrastructure.Authorization;
using MobyLabWebProgramming.Infrastructure.Services.Interfaces;

namespace MobyLabWebProgramming.Backend.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class OrganizationController(IOrganizationService organizationService, IUserService userService)
    : AuthorizedController(userService)
{
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RequestResponse<OrganizationDTO>>> GetById([FromRoute] Guid id)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null ?
            FromServiceResponse(await organizationService.GetOrganization(id)) :
            ErrorMessageResult<OrganizationDTO>(currentUser.Error);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<RequestResponse<PagedResponse<OrganizationDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null ?
            FromServiceResponse(await organizationService.GetOrganizations(pagination)) :
            ErrorMessageResult<PagedResponse<OrganizationDTO>>(currentUser.Error);
    }

    [Authorize(Roles = "Admin")] // Poate doar Admini pot adăuga organizații
    [HttpPost]
    public async Task<ActionResult<RequestResponse>> Add([FromBody] OrganizationAddDTO organization)
    {
        Console.WriteLine("Add Organization");
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null ?
            FromServiceResponse(await organizationService.AddOrganization(organization, currentUser.Result)) :
            ErrorMessageResult(currentUser.Error);
        // if (currentUser.Result != null)
        // {
        //     return FromServiceResponse(await organizationService.AddOrganization(organization, currentUser.Result));
        // }
        //
        // return ErrorMessageResult(currentUser.Error);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut]
    public async Task<ActionResult<RequestResponse>> Update([FromBody] OrganizationUpdateDTO organization)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null ?
            FromServiceResponse(await organizationService.UpdateOrganization(organization, currentUser.Result)) :
            ErrorMessageResult(currentUser.Error);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null ?
            FromServiceResponse(await organizationService.DeleteOrganization(id)) :
            ErrorMessageResult(currentUser.Error);
    }
    
    [Authorize]
    [HttpGet("details/{id:guid}")]
    public async Task<ActionResult<RequestResponse<OrganizationDetailsDTO>>> GetOrganizationDetailsById([FromRoute] Guid id)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await organizationService.GetOrganizationProject(id))
            : ErrorMessageResult<OrganizationDetailsDTO>(currentUser.Error);
    }

}
