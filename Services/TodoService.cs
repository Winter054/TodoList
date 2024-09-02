using TodoList.Models;

namespace TodoList.Services
{
    public class TodoService
    {
        private readonly List<TodoItem> _todoItems = new List<TodoItem>
        {
            new TodoItem { Id = 1, Name = "Buy groceries", IsCompleted = false },
            new TodoItem { Id = 2, Name = "Walk the dog", IsCompleted = true }
        };

        public List<TodoItem> GetTodoItems()
        {
            return _todoItems;
        }

        public void AddTodo(TodoItem newItem)
        {
            newItem.Id = _todoItems.Any() ? _todoItems.Max(item => item.Id) + 1 : 1; 
            _todoItems.Add(newItem);
        }

        public void RemoveTodo(int id)
        {
            var itemToRemove = _todoItems.FirstOrDefault(item => item.Id == id);
            if (itemToRemove != null)
            {
                _todoItems.Remove(itemToRemove);
            }
        }

        public void UpdateTodo(TodoItem updatedItem)
        {
            var existingItem = _todoItems.FirstOrDefault(item => item.Id == updatedItem.Id);
            if (existingItem != null)
            {
                existingItem.Name = updatedItem.Name;
                existingItem.IsCompleted = updatedItem.IsCompleted;
            }
        }
    }
}