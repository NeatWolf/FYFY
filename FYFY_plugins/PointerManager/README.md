PointerManager
==============

This plugin provides components to manage Pointer in a consistent manner with ECS formalism.

Build requirements
------------------

- Unity3D 5.3.4
- Microsoft .Net Framework 4.0
- FYFY.dll

Build
-----

Once the requirements have been installed, use the following command in order
to compile the library:

	<path-to-msbuild>\MSBuild.exe PointerManager.csproj

If Unity3D is not installed in a standard location, you have to define the
`UnityEnginePath` and `UnityEditorPath` properties inside the `PointerManager.csproj`
file. Similarly, you have to define the `FYFYPath` property if FYFY is not
build in its common directory.

Note that common path to MSBuild is:
	
	<path-to-windows>\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe

Usage
-----

To use the library inside an Unity project, you just have to drop it and 
`FYFY.dll` in the `Assets` folder of your project.

Directories list
----------------

- src: project sources files