namespace Free.FileFormats.VRML.Interfaces
{
	/// <summary>
	/// This abstract interface is the basis for all metadata nodes. The
	/// interface is inherited by all metadata nodes.
	/// 
	/// The specification of the reference field is optional. If provided,
	/// it identifies the metadata standard or other specification that
	/// defines the name field. If the reference field is not provided
	/// or is empty, the meaning of the name field is considered implicit
	/// to the characters in the string.
	/// </summary>
	public interface X3DMetadataObject
	{
		string Name { get; set; }
		string Reference { get; set; }
	}
}
