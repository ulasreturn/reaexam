using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Business.Services.Interface;
using Business.Models.Request.Create;
using Business.Models.Request.Update;
using Business.Models.Response;
using Infrastructure.Data.Postgres.Entities;
using Web.Controllers.Base;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Postgres.EntityFramework;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web.Controllers
{

  public class CommentController : BaseCrudController<Comment, int, CreateCommentDto, UpdateCommentDto, CommentInfoDto>
  {

    private PostgresContext _context;

    public CommentController(ICommentService service, PostgresContext context) : base(service)
    {
      _context = context;
    }


    // Özel işlemler veya endpoint'ler buraya eklenebilir

    // Örneğin, özel bir HTTP GET işlemi ekleyelim:
    [HttpGet]
    public IActionResult GetAllComments()
    {
      // Comment verilerini yükleyin
      var comments = _context.Comment
            .Include(c => c.User)
            .Include(c => c.Employee)
                    .Select(comment => new
                    {
                      id=comment.Id,
                      commentText = comment.CommentText,
                      commentDate = comment.CommentDate,
                      userId=comment.UserId,
                        employeeId = comment.EmployeeId,
                        userName = comment.User.UserName,
                      userPhoto=comment.User.UserPhoto
                    })
        .ToList();

      var options = new JsonSerializerOptions
      {
        ReferenceHandler = ReferenceHandler.Preserve,
        MaxDepth = 500 // Derinlik sınırını artırın
      };
      var json = JsonSerializer.Serialize(comments, options);

      // JSON formatında yanıt döndürmek için bir IActionResult oluşturun
      IActionResult response = new ContentResult
      {

        Content = json,  // Verileri JSON formatına dönüştürün
        ContentType = "application/json", // İçerik türünü JSON olarak belirtin
        StatusCode = 200 // HTTP 200 (Başarılı) durum kodunu ayarlayın
      };

      return response;


    }
  }
}


