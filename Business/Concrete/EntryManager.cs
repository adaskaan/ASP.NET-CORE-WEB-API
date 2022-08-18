using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concrete.EntityFramework;
using Core.Utilites.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class EntryManager : IEntryService
    {
        private IEntryDal _entryDal;
        public EntryManager(IEntryDal entryDal)
        {
            _entryDal = entryDal;
        }

        public IResult Add(Entry entry)
        {
            _entryDal.Add(entry);
            return new SuccessResult(Messages.EntryAdded);  
        }

        public IResult Delete(Entry entry)
        {
            _entryDal.Delete(entry);
            return new SuccessResult(Messages.EntryDeleted);
        }

        public IDataResult <Entry> Get(int id)
        {

            return new SuccessDataResult<Entry>(_entryDal.Get(filter: e => e.Id == id)) ;
        }

        public IDataResult<List<Entry>> GetList()
        {
            return new SuccessDataResult<List<Entry>>(_entryDal.GetList().ToList());
        }

        public IDataResult<List<Entry>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Entry>> (_entryDal.GetList().Where(e => e.categoryId == categoryId).ToList());   
        }

        public IResult Update(Entry entry)
        {
            _entryDal.Update(entry);
            return new SuccessResult(Messages.EntryUpdated);
        }
    }
}
