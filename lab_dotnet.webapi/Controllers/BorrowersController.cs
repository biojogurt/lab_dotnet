using lab_dotnet.entity.Models.CreditHistory;
using lab_dotnet.repository;
using Microsoft.AspNetCore.Mvc;

namespace lab_dotnet.webapi.Controllers;

/// <summary>
/// Borrowers endpoints
/// </summary>
[ProducesResponseType(200)]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
public class BorrowersController : ControllerBase
{
    private IRepository<Borrower> _repository;

    /// <summary>
    /// Borrowers controller
    /// </summary>
    public BorrowersController(IRepository<Borrower> repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Get borrowers
    /// </summary>
    [HttpGet]
    public IActionResult GetBorrowers()
    {
        var result = _repository.GetAll();
        return Ok(result);
    }

    /// <summary>
    /// Get borrower by id
    /// </summary>
    [HttpGet("id")]
    public IActionResult GetBorrowerById(Guid id)
    {
        var result = _repository.GetById(id);
        return Ok(result);
    }

    /// <summary>
    /// Get borrower by passport
    /// </summary>
    [HttpGet("passport")]
    public IActionResult GetBorrowerByPassport(int passportSerial, int passportNumber, Guid passportIssuerId, DateTime passportIssueDate)
    {
        var result = _repository.GetAll(x => x.PassportSerial == passportSerial &&
                                             x.PassportNumber == passportNumber &&
                                             x.PassportIssuerId == passportIssuerId &&
                                             x.PassportIssueDate == passportIssueDate)
                                .FirstOrDefault();
        return Ok(result);
    }

    /// <summary>
    /// Create borrower
    /// </summary>
    [HttpPost]
    public IActionResult CreateBorrower(Borrower borrower)
    {
        var result = _repository.Save(borrower);
        return Ok(result);
    }

    /// <summary>
    /// Replace borrower
    /// </summary>
    [HttpPut]
    public IActionResult ReplaceBorrower(Borrower borrower)
    {
        return CreateBorrower(borrower);
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