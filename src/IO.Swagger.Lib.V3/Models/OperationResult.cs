/*
 * DotAAS Part 2 | HTTP/REST | Repository Service Specification
 *
 * The entire Repository Service Specification as part of Details of the Asset Administration Shell Part 2
 *
 * OpenAPI spec version: V3.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class OperationResult : IEquatable<OperationResult>
    {
        /// <summary>
        /// Gets or Sets ExecutionResult
        /// </summary>

        [DataMember(Name = "executionResult")]
        public Result ExecutionResult { get; set; }

        /// <summary>
        /// Gets or Sets ExecutionState
        /// </summary>

        [DataMember(Name = "executionState")]
        public ExecutionState ExecutionState { get; set; }

        /// <summary>
        /// Gets or Sets InoutputArguments
        /// </summary>

        [DataMember(Name = "inoutputArguments")]
        public List<OperationVariable> InoutputArguments { get; set; }

        /// <summary>
        /// Gets or Sets OutputArguments
        /// </summary>

        [DataMember(Name = "outputArguments")]
        public List<OperationVariable> OutputArguments { get; set; }

        /// <summary>
        /// Gets or Sets RequestId
        /// </summary>

        [MaxLength(128)]
        [DataMember(Name = "requestId")]
        public string RequestId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class OperationResult {\n");
            sb.Append("  ExecutionResult: ").Append(ExecutionResult).Append("\n");
            sb.Append("  ExecutionState: ").Append(ExecutionState).Append("\n");
            sb.Append("  InoutputArguments: ").Append(InoutputArguments).Append("\n");
            sb.Append("  OutputArguments: ").Append(OutputArguments).Append("\n");
            sb.Append("  RequestId: ").Append(RequestId).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((OperationResult)obj);
        }

        /// <summary>
        /// Returns true if OperationResult instances are equal
        /// </summary>
        /// <param name="other">Instance of OperationResult to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(OperationResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ExecutionResult == other.ExecutionResult ||
                    ExecutionResult != null &&
                    ExecutionResult.Equals(other.ExecutionResult)
                ) &&
                (
                    ExecutionState == other.ExecutionState ||
                    ExecutionState != null &&
                    ExecutionState.Equals(other.ExecutionState)
                ) &&
                (
                    InoutputArguments == other.InoutputArguments ||
                    InoutputArguments != null &&
                    InoutputArguments.SequenceEqual(other.InoutputArguments)
                ) &&
                (
                    OutputArguments == other.OutputArguments ||
                    OutputArguments != null &&
                    OutputArguments.SequenceEqual(other.OutputArguments)
                ) &&
                (
                    RequestId == other.RequestId ||
                    RequestId != null &&
                    RequestId.Equals(other.RequestId)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (ExecutionResult != null)
                    hashCode = hashCode * 59 + ExecutionResult.GetHashCode();
                if (ExecutionState != null)
                    hashCode = hashCode * 59 + ExecutionState.GetHashCode();
                if (InoutputArguments != null)
                    hashCode = hashCode * 59 + InoutputArguments.GetHashCode();
                if (OutputArguments != null)
                    hashCode = hashCode * 59 + OutputArguments.GetHashCode();
                if (RequestId != null)
                    hashCode = hashCode * 59 + RequestId.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(OperationResult left, OperationResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(OperationResult left, OperationResult right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
