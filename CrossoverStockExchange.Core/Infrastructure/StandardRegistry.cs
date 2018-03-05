using System;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace CrossoverStockExchange.Core.Infrastructure
{
	public class StandardRegistry : Registry
	{
		public StandardRegistry()
		{
			Scan(scan =>
			{
				scan.TheCallingAssembly();
				scan.WithDefaultConventions();
            });
		}
	}
}