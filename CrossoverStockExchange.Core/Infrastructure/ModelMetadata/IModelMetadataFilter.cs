using System;
using System.Collections.Generic;

namespace CrossoverStockExchange.Core.Infrastructure.ModelMetadata
{
	public interface IModelMetadataFilter
	{
		void TransformMetadata(System.Web.Mvc.ModelMetadata metadata,
			IEnumerable<Attribute> attributes);
	}
}