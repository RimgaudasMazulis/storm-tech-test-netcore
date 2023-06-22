using System.Collections.Generic;
using System.Linq;
using Todo.Data.Entities;
using Todo.Models.TodoItems;

namespace Todo.EntityModelMappers.TodoItems
{
    public static class TodoItemHelper
    {
        public static IEnumerable<TodoItemSummaryViewmodel> OrderBy(this IEnumerable<TodoItemSummaryViewmodel> items,  OrderBy orderBy)
        {
            switch (orderBy)
            {
                case Data.Entities.OrderBy.Rank:
                    return items.OrderBy(o => o.Rank);
                case Data.Entities.OrderBy.Importance:
                default:
                    return items.OrderBy(o => o.Importance);
            }
        }
    }
}
