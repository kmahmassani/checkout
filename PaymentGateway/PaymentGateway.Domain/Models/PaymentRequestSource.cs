/*
 * Payment Gateway
 *
 * Gateway to facilitate processing payments and to retrieve payment details. 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: kmahmassani@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace PaymentGateway.Domain.Models
{ 
    /// <summary>
    /// A card payment source
    /// </summary>
    [DataContract]
    public partial class PaymentRequestSource : IEquatable<PaymentRequestSource>
    { 
        /// <summary>
        /// The type of payment source. Set this to &#x60;card&#x60;.
        /// </summary>
        /// <value>The type of payment source. Set this to &#x60;card&#x60;.</value>
        [Required]
        [DataMember(Name="type")]
        public string Type { get; set; }

        /// <summary>
        /// The card number (without separators)
        /// </summary>
        /// <value>The card number (without separators)</value>
        [Required]
        [DataMember(Name="number")]
        public string Number { get; set; }

        /// <summary>
        /// The expiry month of the card
        /// </summary>
        /// <value>The expiry month of the card</value>
        [Required]
        [DataMember(Name="expiry_month")]
        public int? ExpiryMonth { get; set; }

        /// <summary>
        /// The expiry year of the card
        /// </summary>
        /// <value>The expiry year of the card</value>
        [Required]
        [DataMember(Name="expiry_year")]
        public int? ExpiryYear { get; set; }

        /// <summary>
        /// The name of the cardholder
        /// </summary>
        /// <value>The name of the cardholder</value>
        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// The card verification value/code. 3 digits, except for Amex (4 digits)
        /// </summary>
        /// <value>The card verification value/code. 3 digits, except for Amex (4 digits)</value>
        [DataMember(Name="cvv")]
        public string Cvv { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PaymentRequestSource {\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Number: ").Append(Number).Append("\n");
            sb.Append("  ExpiryMonth: ").Append(ExpiryMonth).Append("\n");
            sb.Append("  ExpiryYear: ").Append(ExpiryYear).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Cvv: ").Append(Cvv).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PaymentRequestSource)obj);
        }

        /// <summary>
        /// Returns true if PaymentRequestSource instances are equal
        /// </summary>
        /// <param name="other">Instance of PaymentRequestSource to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PaymentRequestSource other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Type == other.Type ||
                    Type != null &&
                    Type.Equals(other.Type)
                ) && 
                (
                    Number == other.Number ||
                    Number != null &&
                    Number.Equals(other.Number)
                ) && 
                (
                    ExpiryMonth == other.ExpiryMonth ||
                    ExpiryMonth != null &&
                    ExpiryMonth.Equals(other.ExpiryMonth)
                ) && 
                (
                    ExpiryYear == other.ExpiryYear ||
                    ExpiryYear != null &&
                    ExpiryYear.Equals(other.ExpiryYear)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Cvv == other.Cvv ||
                    Cvv != null &&
                    Cvv.Equals(other.Cvv)
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
                    if (Type != null)
                    hashCode = hashCode * 59 + Type.GetHashCode();
                    if (Number != null)
                    hashCode = hashCode * 59 + Number.GetHashCode();
                    if (ExpiryMonth != null)
                    hashCode = hashCode * 59 + ExpiryMonth.GetHashCode();
                    if (ExpiryYear != null)
                    hashCode = hashCode * 59 + ExpiryYear.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Cvv != null)
                    hashCode = hashCode * 59 + Cvv.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(PaymentRequestSource left, PaymentRequestSource right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PaymentRequestSource left, PaymentRequestSource right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
