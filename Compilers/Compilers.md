Both the Java and C# compilers compile to an "machine code" for an intermediate virtual machine that is independent of the ultimate execution platform; the JVM and CLR respectively.


JVM was originally designed solely to support Java. While it is possible to compile languages other than Java to run on a JVM, there are aspects of its design that are not entirely suited to certain classes of language. By contrast, the CLR and its instruction set were designed from day one to support a range of languages.


Another difference is in the way that JIT compilation works. According to Wikipedia, CLR is designed to run fully compiled code, so (presumably) the CLR's JIT compiler must eagerly compile the entire application before starting. (I also gather that you can compile the bytecodes to native code ahead of time.) By contrast, the Hotspot JVMs use true "just in time" compilation. Bytecode methods are initially executed by the JVM using a bytecode interpreter, which also gathers trace information about execution paths taken within the method. Those methods that are executed a number of times then get compiled to native code by the JIT compiler, using the captured trace information to help in the code optimization. This allows the native code to be optimized for the actual execution platform and even for the behaviour of the current execution of the application.


Of course, the C# and Java languages have many significant differences, and the corresponding compilers are different because of the need to handle these linguistic differences. For example, C# compilers do more type inferencing ... because the C# language relies more on inferred types.
