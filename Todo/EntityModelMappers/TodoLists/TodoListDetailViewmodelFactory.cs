using System.Linq;
using Todo.Data.Entities;
using Todo.EntityModelMappers.TodoItems;
using Todo.Models.TodoLists;

namespace Todo.EntityModelMappers.TodoLists
{
    public static class TodoListDetailViewmodelFactory
    {
        public static TodoListDetailViewmodel Create(TodoList todoList, OrderBy orderBy)
        {
            var items = todoList.Items
                .Select(TodoItemSummaryViewmodelFactory.Create)
                .OrderBy(orderBy)
                .ToList();

            var createTodoItemFields = TodoItemCreateFieldsFactory.Create(todoList, todoList.Owner.Id);

            return new TodoListDetailViewmodel(todoList.TodoListId, todoList.Title, items, createTodoItemFields);
        }
    }
}