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
            var items = todoList.Items.Select(TodoItemSummaryViewmodelFactory.Create).ToList();

            switch (orderBy)
            {
                case OrderBy.Rank:
                    items = items.OrderBy(o => o.Rank).ToList();
                    break;
                case OrderBy.Importance:
                default:
                    items = items.OrderBy(o => o.Importance).ToList();
                    break;
            }

            return new TodoListDetailViewmodel(todoList.TodoListId, todoList.Title, items);
        }
    }
}