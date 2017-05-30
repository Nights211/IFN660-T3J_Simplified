
.assembly XEquals42
{
}
.module XEquals42.exe

.class HelloWorld
{
  .method static void  Main(string[] args)
  {
    .entrypoint
    .locals init (int32 x)
    ldc.i4.s   42
    stloc.0
    ret
  }
} 