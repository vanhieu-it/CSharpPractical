using MinimalAPI.Models;

namespace MinimalAPI.Services
{
    public class TodoService
    {
        private readonly List<Todo> _todos = new();
        public IEnumerable<Todo> GetAllTodos () => _todos;
        public Todo? GetTodoById(int id) => _todos.FirstOrDefault(t=>t.Id == id);
        public void AddTodo(Todo todo)
        {
            todo.Id = _todos.Count + 1;
            _todos.Add(todo);
        }
        public bool UpdateTodo(int id, Todo updateTodo)
        {
            var existingTodo = GetTodoById(id);
            if (existingTodo is null) { return false; };

            existingTodo.Title = updateTodo.Title;
            existingTodo.IsComplete = updateTodo.IsComplete;
            return true;
        }
        public bool DeleteTodo(int id) {
            var todo = GetTodoById(id);
            if (todo is null)
            {
                return false;
            }
            _todos.Remove(todo);
            return true;
        }
    }
}
