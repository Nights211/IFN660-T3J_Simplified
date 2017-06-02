.assembly Helloworld { }
.class public Helloworld 
{
.method public static void Main(string[] args)
{
.entrypoint
.locals init ([0] int32 x)
ldc.i4 42
stloc x
ldloc x
pop
ldloc x
ldc.i4 2
sub
pop
ret
}
}