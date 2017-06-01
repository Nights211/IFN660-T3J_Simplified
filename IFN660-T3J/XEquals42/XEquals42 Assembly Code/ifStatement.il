
.assembly XEquals42 {}

.class HelloWorld
{
  .method static void Main(string[] args)
  {
    .entrypoint
    .locals init ([0] int32 x, [1] bool V_1)
    IL_0001:  ldc.i4.s   42
    IL_0003:  stloc.0
    IL_0004:  ldloc.0
    IL_0005:  ldc.i4.s   42
    IL_0007:  ceq
    IL_0009:  stloc.1
    IL_000a:  ldloc.1
    IL_000b:  brfalse.s  IL_0011
    IL_000d:  nop
    IL_000e:  ldc.i4.3
    IL_000f:  stloc.0
    IL_0010:  nop
    IL_0011:  ret
  } 

}