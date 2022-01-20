using System;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Contents.Application.Contents.Queries.GetContentList;
using Contents.Application.Contents.Queries.GetContentDescriptions;
using Contents.Application.Contents.Commands.AddContent;
using Contents.Application.Contents.Commands.UpdateContent;
using Contents.Application.Contents.Commands.DeleteCommand;
using Contents.WebApi.Models;

namespace Contents.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ContentController : BaseController
    {
        private readonly IMapper _mapper;

        public ContentController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Gets the list of files
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /content
        /// </remarks>
        /// <returns>Returns ContentListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ContentListVm>> GetAll()
        {
            var query = new GetContentListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the file by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /content/E1DFB33C-413C-4C3A-8CEF-D0B226FE1318
        /// </remarks>
        /// <param name="id">Note id (guid)</param>
        /// <returns>Returns ContentDescriptionVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user in unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ContentDescriptionsVm>> Get(Guid id)
        {
            var query = new GetContentDescriptionsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Adds the content(file)
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /content
        /// {
        ///     title: "content title",
        ///     description: "content description"
        /// }
        /// </remarks>
        /// <param name="addContentDto">AddContentDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Add([FromBody] AddContentDto addContentDto)
        {
            var command = _mapper.Map<AddContentCommand>(addContentDto);
            command.UserId = UserId;
            var contentId = await Mediator.Send(command);
            return Ok(contentId);
        }

        /// <summary>
        /// Updates the content (file)
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /content
        /// {
        ///     title: "updated content title"
        /// }
        /// </remarks>
        /// <param name="updateContentDto">UpdateContentDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateContentDto updateContentDto)
        {
            var command = _mapper.Map<UpdateContentCommand>(updateContentDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the content(file) by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /content/AD7A4242-1E06-473E-936B-492CC9997CD2
        /// </remarks>
        /// <param name="id">Id of the content (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteContentCommand
            {
                Id = id,
                UserId = UserId
            };

            await Mediator.Send(command);
            return NoContent();
        }

    }
}
