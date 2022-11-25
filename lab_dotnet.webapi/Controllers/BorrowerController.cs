using AutoMapper;
using lab_dotnet.Entities.Models;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using lab_dotnet.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.WebAPI.Controllers;

/// <summary>
/// Borrowers endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class BorrowerController : ControllerBase
{
    private readonly IBorrowerService Service;
    private readonly IMapper Mapper;

    /// <summary>
    /// Borrowers controller
    /// </summary>
    public BorrowerController(IBorrowerService service, IMapper mapper)
    {
        Service = service;
        Mapper = mapper;
    }

    /// <summary>
    /// Get borrowers
    /// </summary>
    [HttpGet]
    public IActionResult GetBorrowers([FromQuery] int limit = 20, [FromQuery] int offset = 0)
    {
        var pageModel = Service.GetBorrowers(limit, offset);
        var pageResponse = Mapper.Map<PageResponse<BorrowerResponse>>(pageModel);
        return Ok(pageResponse);
    }

    /// <summary>
    /// Get borrower by id
    /// </summary>
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetBorrowerById([FromRoute] Guid id)
    {
        try
        {
            var borrowerResponse = Mapper.Map<BorrowerResponse>(Service.GetBorrowerById(id));
            return Ok(borrowerResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Get borrower by passport
    /// </summary>
    [HttpGet("passport")]
    public IActionResult GetBorrowerByPassport([FromBody] PassportRequest passport)
    {
        try
        {
            var passportModel = Mapper.Map<PassportModel>(passport);
            var borrowerModel = Service.GetBorrowerByPassport(passportModel);
            var borrowerResponse = Mapper.Map<BorrowerResponse>(borrowerModel);
            return Ok(borrowerResponse);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    /// <summary>
    /// Update borrower
    /// </summary>
    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateBorrower([FromRoute] Guid id, [FromBody] UpdateBorrowerRequest borrowerRequest)
    {
        var validationResult = borrowerRequest.Validate();

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        var borrowerModel = Mapper.Map<UpdateBorrowerModel>(borrowerRequest);

        if (borrowerModel == null)
        {
            return BadRequest("No such borrower");
        }

        var borrowerResult = Service.UpdateBorrower(id, borrowerModel);
        return Ok(borrowerResult);
    }

    /// <summary>
    /// Delete borrower by class instance
    /// </summary>
    [HttpDelete]
    public IActionResult DeleteBorrower(Borrower borrower)
    {
        var result = _repository.Delete(borrower);
        return result ? Ok() : NotFound();
    }

    /// <summary>
    /// Delete borrower by id
    /// </summary>
    [HttpDelete("id")]
    public IActionResult DeleteBorrowerById(Guid id)
    {
        var borrower = _repository.GetById(id);

        if (borrower != null)
        {
            _repository.Delete(borrower);
            return Ok();
        }

        return NotFound();
    }

    /// <summary>
    /// Delete borrower by passport
    /// </summary>
    [HttpDelete("passport")]
    public IActionResult DeleteBorrowerByPassport(int passportSerial, int passportNumber, Guid passportIssuerId, DateTime passportIssueDate)
    {
        var borrower = _repository.GetAll(x => x.PassportSerial == passportSerial &&
                                             x.PassportNumber == passportNumber &&
                                             x.PassportIssuerId == passportIssuerId &&
                                             x.PassportIssueDate == passportIssueDate)
                                .FirstOrDefault();

        if (borrower != null)
        {
            _repository.Delete(borrower);
            return Ok();
        }

        return NotFound();
    }
}