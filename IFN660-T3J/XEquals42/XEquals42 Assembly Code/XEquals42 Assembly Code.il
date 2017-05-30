.assembly XEquals42
{
}
.module XEquals42.exe

.class HelloWorld
{
  .method static void  Main(string[] args)
  {
    .entrypoint
    .locals init (int32 x, int32 y)
    ldc.i4.s   42
    stloc.0
    ldloc.0
    ldc.i4.1
    add
    stloc.1
    ldloc.1
    call       void [mscorlib]System.Console::WriteLine(int32)
    ret
  } 
}