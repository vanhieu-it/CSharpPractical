using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using MinimalAPI.Models;
using MinimalAPI.Services;

namespace MinimalAPI.Controllers
{
    public static class TodoController
    {
        public static void MapTodoEndpoints(this WebApplication app)
        {
            // Endpoint GET: Lấy tất cả các todo
            app.MapGet("/todos", ([FromServices] TodoService todoService) =>
                todoService.GetAllTodos()
            );

            // Endpoint GET: Lấy chi tiết một todo theo Id
            app.MapGet("/todos/{id:int}", (int id, [FromServices] TodoService todoService) =>
            {
                var todo = todoService.GetTodoById(id);
                return todo is not null ? Results.Ok(todo) : Results.NotFound();
            });

            // Endpoint POST: Thêm một todo mới
            app.MapPost("/todos", ([FromBody] Todo todo, [FromServices] TodoService todoService) =>
            {
                todoService.AddTodo(todo);
                return Results.Created($"/todos/{todo.Id}", todo);
            });

            // Endpoint PUT: Cập nhật một todo theo Id
            app.MapPut("/todos/{id:int}", (int id, [FromBody] Todo updateTodo, [FromServices] TodoService todoService) =>
            {
                var updated = todoService.UpdateTodo(id, updateTodo);
                return updated ? Results.NoContent() : Results.NotFound();
            });

            // Endpoint DELETE: Xóa một todo theo Id
            app.MapDelete("/todos/{id:int}", (int id, [FromServices] TodoService todoService) =>
            {
                var deleted = todoService.DeleteTodo(id);
                return deleted ? Results.NoContent() : Results.NotFound();
            });
        }
    }
}
