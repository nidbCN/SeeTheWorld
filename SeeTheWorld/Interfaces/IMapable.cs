namespace SeeTheWorld.Interfaces
{
    public interface IMapable<TSrc, TDest>
    {
        public TDest MapTo(TSrc source);
        public void MapFrom(TDest source);
    }
}
