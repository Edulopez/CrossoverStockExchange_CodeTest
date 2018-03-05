using System.Web;
using StructureMap;

namespace CrossoverStockExchange.Core.Infrastructure
{
	public static class ContainerPerRequestExtensions
	{
		public static StructureMap.IContainer GetContainer(this HttpContextBase context)
		{
			return (IContainer) HttpContext.Current.Items["_Container"] 
				?? ObjectFactory.Container;
		}
	}
}