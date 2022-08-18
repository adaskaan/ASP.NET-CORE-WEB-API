using Core.Utilites.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEntryService
    {
        IDataResult<Entry> Get(int id);
        IDataResult <List<Entry>> GetList();
        IDataResult <List<Entry>> GetListByCategory(int categoryId);

        IResult  Add(Entry entry);
        IResult Update(Entry entry);
        IResult Delete(Entry entry);
    }
}
