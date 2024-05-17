using Entitiyes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace Repository.EFCore.Extensions
{
    public static class MeetingRepoExtensions
    {
        public static IQueryable<Meeting> MeetingSearch(this IQueryable<Meeting> meetings,string? searchTerm) {
            if (string.IsNullOrWhiteSpace(searchTerm)) { 
            return meetings;
            }
            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return meetings.Where(x => x.Title.ToLower().Contains(lowerCaseTerm));
        
        } 
        public static IQueryable<Meeting> ShortMeeting(this IQueryable<Meeting> meetings,string? orderByQueryString) {

            if (string.IsNullOrWhiteSpace(orderByQueryString)) { 
            return meetings.OrderBy(x => x.CreateDate);
            }

            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfo = typeof(Meeting).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQuery = OrderQueryBuilder.CreateOrderQuery<Meeting>(orderByQueryString);
            if (orderQuery is null)
                return meetings.OrderBy(x => x.CreateDate);

            return meetings.OrderBy(orderQuery);
        }
    }
    
}
