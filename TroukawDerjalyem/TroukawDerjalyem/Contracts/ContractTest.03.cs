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
using System.Threading.Tasks;

namespace MSTest.Extensions.Contracts
{
    public static partial class ContractTest
    {
        /// <summary>
        /// Create a test case for the specified <paramref name="contract"/>.
        /// </summary>
        /// <param name="contract">The description of a test contract.</param>
        /// <param name="testCase">The action which is used to test the contract.</param>
        [System.Diagnostics.Contracts.Pure, NotNull, PublicAPI]
        public static ContractTestContext<T1, T2, T3> Test<T1, T2, T3>([NotNull] this string contract, [NotNull] Action<T1, T2, T3> testCase)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (testCase == null) throw new ArgumentNullException(nameof(testCase));

            Contract.EndContractBlock();

            return new ContractTestContext<T1, T2, T3>(contract, testCase);
        }

        /// <summary>
        /// Create an async test case for the specified <paramref name="contract"/>.
        /// </summary>
        /// <param name="contract">The description of a test contract.</param>
        /// <param name="testCase">The async action which is used to test the contract.</param>
        [System.Diagnostics.Contracts.Pure, NotNull, PublicAPI]
        public static ContractTestContext<T1, T2, T3> Test<T1, T2, T3>([NotNull] this string contract, [NotNull] Func<T1, T2, T3, Task> testCase)
        {
            if (contract == null) throw new ArgumentNullException(nameof(contract));
            if (testCase == null) throw new ArgumentNullException(nameof(testCase));

            Contract.EndContractBlock();

            return new ContractTestContext<T1, T2, T3>(contract, testCase);
        }
    }
}
