﻿namespace SmartphoneRentStore.Core.Constants
{
    public static class MessageConstants
    {
        public const string RequiredMessage = "The {0} field is required!";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string PhoneExits = "Phone number already exists. Enter another one";

        public const string HasRents = "You should have no rents to become an agent";

        public const string SuccessRented = "SuccessRented";

        public const string NotRenterUserError = "The user is not the renter!";

        public const string UserMessageSuccess = "UserMessageSuccess";

        public const string UserMessageError = "UserMessageError";
    }
}
