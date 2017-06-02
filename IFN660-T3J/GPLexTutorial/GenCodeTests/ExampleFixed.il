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
ldc.i4 1
add
stloc x
ldloc x
ldstr      "X = {0}"
ldloc x
box        [mscorlib]System.Int32
call       void [mscorlib]System.Console::WriteLine(string, object)
nop
ret
}
}