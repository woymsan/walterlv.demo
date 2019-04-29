//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#define GENERATED_CODE

using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MSTest.Extensions.Core;
#if GENERATED_CODE
using CanBeNullWhenTIsSingle = MSTest.Extensions.NotNullAttribute;
#else
using CanBeNullWhenTIsSingle = MSTest.Extensions.CanBeNullAttribute;
#endif

namespace MSTest.Extensions.Contracts
{
    /// <summary>
    /// Provides builder for a particular contracted test case.
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("https://github.easiwin.io/mstest-enhancer", "1.0")]
    public class ContractTestContext<T1, T2, T3, T4>
    {
        /// <summary>
        /// Create a new <see cref="ContractTestContext{T1, T2, T3, T4}"/> instance with contract description and testing action.
        /// </summary>
        /// <param name="contract">The contract description string for this test case.</param>
        /// <param name="testCase">The actual action to execute the test case.</param>
        public ContractTestContext([NotNull] string contract, [NotNull] Action<T1, T2, T3, T4> testCase)
        {
            _contract = contract ?? throw new ArgumentNullException(nameof(contract));
            if (testCase == null) throw new ArgumentNullException(nameof(testCase));
#if NET45
#pragma warning disable CS1998 // Async function without await expression
            _testCase = async (t1, t2, t3, t4) => testCase(t1, t2, t3, t4);
#pragma warning restore CS1998 // Async function without await expression
#else
            _testCase = (t1, t2, t3, t4) =>
            {
                testCase(t1, t2, t3, t4);
                return Task.CompletedTask;
            };
#endif
        }

        /// <summary>
        /// Create a new <see cref="ContractTestContext{T1, T2, T3, T4}"/> instance with contract description and async testing action.
        /// </summary>
        /// <param name="contract">The contract description string for this test case.</param>
        /// <param name="testCase">The actual async action to execute the test case.</param>
        public ContractTestContext([NotNull] string contract, [NotNull] Func<T1, T2, T3, T4, Task> testCase)
        {
            _contract = contract ?? throw new ArgumentNullException(nameof(contract));
            _testCase = testCase ?? throw new ArgumentNullException(nameof(testCase));
        }

        /// <summary>
        /// When the test case is executed, pass the argument(s) to the test case action.
        /// </summary>
        /// <param name="ts">The argument(s) that will be passed into the test case action.</param>
        /// <returns>The instance itself.</returns>
        /// <remarks>
        /// Note that we only verify the <paramref name="ts"/> argument in runtime. In this case, we have the power to pass an array instead of writing them all in a method parameter list.
        /// </remarks>
        [NotNull, PublicAPI]
        public ContractTestContext<T1, T2, T3, T4> WithArguments([CanBeNullWhenTIsSingle] params (T1, T2, T3, T4)[] ts)
        {
            if (ts == null)
            {
#if GENERATED_CODE
                throw new ArgumentNullException(nameof(ts));
#else
                ts = new (T1, T2, T3, T4)[] { default };
#endif
            }
            if (ts.Length < 1)
            {
                throw new ArgumentException(
                    $"At least one argument should be passed into test case {_contract}", nameof(ts));
            }
            Contract.EndContractBlock();

#if !GENERATED_CODE
#endif
            // Check if every argument will be formatted into the contract.
            var allFormatted = true;
            for (var i = 0; i < ts.Length; i++)
            {
                allFormatted = _contract.Contains($"{{{i}}}");
                if (!allFormatted) break;
            }

            foreach (var (t1, t2, t3, t4) in ts)
            {
                // If any argument is not formatted, post the argument value at the end of the contract string.
                var contract = string.Format(_contract, ForT(t1), ForT(t2), ForT(t3), ForT(t4));
                if (!allFormatted)
                {
                    contract = contract + $"({ForT(t1)}, {ForT(t2)}, {ForT(t3)}, {ForT(t4)})";
                }

                // Add an argument test case to the test case list.
                ContractTest.Method.Current.Add(new ContractTestCase(contract, () => _testCase(t1, t2, t3, t4)));
            }

            return this;
        }

        /// <summary>
        /// For null value, the formatted string is "Null".
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private string ForT<TInput>([CanBeNull] TInput value)
        {
            return value == null ? "Null" : value.ToString();
        }

#if GENERATED_CODE
        /// <summary>
        /// When the test case is executed, pass the arguments to the test case action.
        /// </summary>
        /// <returns>The instance itself.</returns>
        [NotNull, PublicAPI]
        public ContractTestContext<T1, T2, T3, T4> WithArguments(T1 t1, T2 t2, T3 t3, T4 t4)
        {
            ContractTest.Method.Current.Add(new ContractTestCase(
                string.Format(_contract, t1, t2, t3, t4), () => _testCase(t1, t2, t3, t4)));
            return this;
        }
#endif

        /// <summary>
        /// Gets the contract description string for this test case.
        /// </summary>
        [NotNull] private readonly string _contract;

        /// <summary>
        /// Invoke this action to execute this test case with the argument(s).
        /// The returning value of this func will never be null, but it does not mean that it is an async func.
        /// </summary>
        [NotNull] private readonly Func<T1, T2, T3, T4, Task> _testCase;
    }
}
