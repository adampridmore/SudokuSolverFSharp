# SudokuSolverFSharp

fsharpc Script.fsx
mono Script.exe


	C:\Program Files (x86)\Microsoft SDKs\F#\3.1\Framework\v4.0\fsc.exe -o:obj\Debug\SudokuFSharp.exe -g --debug:full --noframework --define:DEBUG --define:TRACE --doc:bin\Debug\SudokuFSharp.XML --optimize- --tailcalls- -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\FSharp\.NETFramework\v4.0\4.3.1.0\FSharp.Core.dll" -r:C:\Users\Adam\Dropbox\Work\Dev\SudokuFSharp\packages\FsUnit.1.3.0.1\Lib\Net40\FsUnit.NUnit.dll -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1\mscorlib.dll" -r:C:\Users\Adam\Dropbox\Work\Dev\SudokuFSharp\packages\NUnit.2.6.3\lib\nunit.framework.dll -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1\System.Core.dll" -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1\System.dll" -r:"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.1\System.Numerics.dll" --target:exe --warn:3 --warnaserror:76 --vserrors --validate-type-providers --LCID:1033 --utf8output --fullpaths --flaterrors --subsystemversion:6.00 --highentropyva+ --sqmsessionguid:81515846-cf61-4c3c-b17f-6001cb7025ce "C:\Users\Adam\AppData\Local\Temp\.NETFramework,Version=v4.5.1.AssemblyAttributes.fs" SudokuSolver.fs SudokuSolverHelpers.fs SudokuSolverTests.fs Main.fs 