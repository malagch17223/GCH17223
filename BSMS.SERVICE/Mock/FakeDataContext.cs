using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;

using System.Data.Common;

using System.Data.Linq;

using System.Data.Linq.Mapping;

using System.Data.Linq.Provider;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using BSMS.SERVICE.App_Data;

namespace BSMS.Tests.Mock
{
    //g
    public class FakeDataContext<E> : ITable<E> where E : class
    {
        ObservableCollection<E> _data = new ObservableCollection<E>();
        IQueryable _query;

        public FakeDataContext()
        {
            _query = _data.AsQueryable();
        }

        public Type ElementType
        {
            get
            {
                return _query.ElementType;
            }
        }

        public Expression Expression
        {
            get
            {
               return _query.Expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _query.Provider;
            }
        }

        public void Attach(E entity)
        {
            _data.Add(entity);
        }

        public void DeleteOnSubmit(E entity)
        {
            _data.Remove(entity);
        }

        public IEnumerator<E> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        public void InsertOnSubmit(E entity)
        {
            _data.Add(entity);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        
    }
}