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
public class ApplicationController(IApplicationService applicationService, IUserService userService) : AuthorizedController(userService)
{
    [Authorize]
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<RequestResponse<ApplicationDTO>>> GetById([FromRoute] Guid id)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.GetApplication(id))
            : ErrorMessageResult<ApplicationDTO>(currentUser.Error);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<RequestResponse<PagedResponse<ApplicationDTO>>>> GetPage([FromQuery] PaginationSearchQueryParams pagination)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.GetApplications(pagination))
            : ErrorMessageResult<PagedResponse<ApplicationDTO>>(currentUser.Error);
    }
    
    [Authorize]
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<RequestResponse<PagedResponse<ApplicationDTO>>>> GetByUser([FromRoute] Guid userId, [FromQuery] PaginationSearchQueryParams pagination)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.GetApplicationsByUser(userId, pagination))
            : ErrorMessageResult<PagedResponse<ApplicationDTO>>(currentUser.Error);
    }

    [Authorize]
    [HttpGet("{projectId:guid}")]
    public async Task<ActionResult<RequestResponse<PagedResponse<ApplicationDTO>>>> GetByProject([FromRoute] Guid projectId, [FromQuery] PaginationSearchQueryParams pagination)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.GetApplicationsByProject(projectId, pagination))
            : ErrorMessageResult<PagedResponse<ApplicationDTO>>(currentUser.Error);
    }

    [Authorize]
    [HttpGet("{organizationId:guid}")]
    public async Task<ActionResult<RequestResponse<PagedResponse<ApplicationDTO>>>> GetByOrganization([FromRoute] Guid organizationId, [FromQuery] PaginationSearchQueryParams pagination)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.GetApplicationsByOrganization(organizationId, pagination))
            : ErrorMessageResult<PagedResponse<ApplicationDTO>>(currentUser.Error);
    }


    // [Authorize]
    // [HttpPost]
    // public async Task<ActionResult<RequestResponse>> Add([FromBody] ApplicationAddDTO application)
    // {
    //     var currentUser = await GetCurrentUser();
    //     return currentUser.Result != null
    //         ? FromServiceResponse(await applicationService.AddApplication(application, currentUser.Result))
    //         : ErrorMessageResult(currentUser.Error);
    // }
    
    [Authorize]
    [HttpPost]
    public async Task<ActionResult<RequestResponse>> Add([FromBody] ApplicationAddDTO application)
    {
        var currentUser = await GetCurrentUser();

        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.AddApplication(application, currentUser.Result))
            : ErrorMessageResult(currentUser.Error);
    }

    [Authorize]
    [HttpPut]
    public async Task<ActionResult<RequestResponse>> Update([FromBody] ApplicationUpdateDTO application)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.UpdateApplication(application, currentUser.Result))
            : ErrorMessageResult(currentUser.Error);
    }

    [Authorize]
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<RequestResponse>> Delete([FromRoute] Guid id)
    {
        var currentUser = await GetCurrentUser();
        return currentUser.Result != null
            ? FromServiceResponse(await applicationService.DeleteApplication(id, currentUser.Result))
            : ErrorMessageResult(currentUser.Error);
    }
}
