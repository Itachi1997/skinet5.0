using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;


            //Getting Recordes by where
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // p => p.producttypeId== id <= Something like dat uk
            }

            // Ordering Spec
            if (spec.orderBy != null)
            {
                query = query.OrderBy(spec.orderBy); // p => p.producttypeId== id <= Something like dat uk
            }

            if (spec.orderByDesc != null)
            {
                query = query.OrderByDescending(spec.orderByDesc); // p => p.producttypeId== id <= Something like dat uk
            }

            if (spec.IsPagingEnabled == true)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }

            //Include Spec
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;
        }
    }
}