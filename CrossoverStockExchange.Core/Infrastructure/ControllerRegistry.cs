using System;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace CrossoverStockExchange.Core.Infrastructure
{
	public class ControllerRegistry : Registry
	{
		public ControllerRegistry()
		{
			Scan(scan =>
			{
				scan.TheCallingAssembly();
				scan.With(new ControllerConvention());
			});
		}
	}
}