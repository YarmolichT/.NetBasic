using DocumentModel.LibraryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Document = DocumentModel.LibraryModel.Document;

namespace DocumentModel.DocumentService
{
    public class DocumentServices: IDocument 
    {        
        public IRepository<Document> _repository;

        public DocumentServices(IRepository<Document> repository)
        {
              _repository = repository;
        }

        public Magazine ValidateDataForMagazine(int Id, string title, string releaseNumber, string publisher) {

            Magazine magazine = new()
            {
                Id = Id,
                Title = title,
                DatePublished = DateTime.Now,
                ReleaseNumber = releaseNumber,
                Publisher = publisher
            };

            return magazine;
        }
    }
}
