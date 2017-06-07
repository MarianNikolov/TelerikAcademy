using SocialNetwork.Data.UnitOfWorks;

namespace SuperheroesUniverse.ConsoleClient.XmlImporters
{
    public class XmlImoirter : IXmlExporter
    {
        private IUnitOfWork unitOfWork;

        public XmlImoirter(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }




    }
}
