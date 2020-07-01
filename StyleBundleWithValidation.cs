using System.IO;
using System.Web.Hosting;
using System.Web.Optimization;

namespace MyApp
{
	public class StyleBundleWithValidation : StyleBundle
	{
		public StyleBundleWithValidation(string virtualPath) : base(virtualPath) { }

		public StyleBundleWithValidation(string virtualPath, string cdnPath) : base(virtualPath, cdnPath) { }

		public override Bundle Include(params string[] virtualPaths)
		{
			foreach (var virtualPath in virtualPaths)
			{
				var physicalPath = HostingEnvironment.MapPath(virtualPath);
				if (!File.Exists(physicalPath))
					throw new FileNotFoundException($"File not found [{physicalPath}]");
			}

			base.Include(virtualPaths);
			return this;
		}
	}
}
