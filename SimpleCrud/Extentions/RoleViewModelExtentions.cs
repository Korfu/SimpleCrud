using SimpleCrud.Models.Roles;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SimpleCrud.Extentions
{
    public static class RoleViewModelExtentions
    {
        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<RoleViewModel> items)
        {
            return items.Select(i => new SelectListItem()
            {
                Value = i.Id.ToString(),
                Text = i.Name
            });
        }
    }
}