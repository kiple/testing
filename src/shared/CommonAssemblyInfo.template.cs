/////////////////////////////////////////////////////////////////////////////
//
//	Template CommonAssemlyInfo.cs
//
//	Не редактируйте файл CommonAssemlyInfo.cs,
//	так как он генерируется автоматически!
//
/////////////////////////////////////////////////////////////////////////////
using System.Reflection;

#if DEBUG
[assembly: AssemblyProduct("Mallenom.SuperAlg[DBG]")]
#else
[assembly: AssemblyProduct("Mallenom.SuperAlg")]
#endif
[assembly: AssemblyCompany("Mallenom Systems")]
[assembly: AssemblyCopyright("© $COMMIT_YEAR_GIT$, Mallenom Systems")]
[assembly: AssemblyTrademark("Mallenom")]
[assembly: AssemblyCulture("")]

[assembly: AssemblyVersion(Rev.Major + "." + Rev.Minor + "." + Rev.Patch + "." + Rev.Revision)]
[assembly: AssemblyFileVersion(Rev.Major + "." + Rev.Minor + "." + Rev.Patch + "." + Rev.Revision)]
[assembly: AssemblyInformationalVersion(Rev.Major + "." + Rev.Minor + "." + Rev.Patch + "-" + Rev.Configuration + "-" + Rev.Revision + "[" + Rev.Hash + "]")]
[assembly: AssemblyConfiguration(Rev.Configuration)]

//[assembly: AssemblyTimeStamp("$COMMIT_DATE_GIT$", "$COMMIT_DATE_GIT$")]

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2243:AttributeStringLiteralsShouldParseCorrectly",
	Justification = "AssemblyInformationalVersion does not need to be a parsable version")]

static class Rev
{ 
	public const string Major = "$MAJOR$";
	public const string Minor = "$MINOR$";
	public const string Patch = "$PATCH$";
	public const string Configuration = "$CONFIG$";
	public const string Revision = "$OFFSET_GIT$";
	public const string Hash = "$HASH_GIT$";
}
