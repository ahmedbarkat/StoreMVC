﻿jQuery.extend(jQuery.validator.messages, {
    required: "البيان مطلوب.",
    remote: "Please fix this field.",
    email: "برجاء ادخال الايميل بطريق صحيحة.",
    url: "Please enter a valid URL.",
    date: "Please enter a valid date.",
    dateISO: "Please enter a valid date (ISO).",
    number: "برجاء ادخال أرقام فقط.",
    digits: "Please enter only digits.",
    creditcard: "Please enter a valid credit card number.",
    equalTo: "Please enter the same value again.",
    accept: "Please enter a value with a valid extension.",
    maxlength: jQuery.validator.format("Please enter no more than {0} characters."),
    minlength: jQuery.validator.format("Please enter at least {0} characters."),
    rangelength: jQuery.validator.format("Please enter a value between {0} and {1} characters long."),
    range: jQuery.validator.format("القيمة ما بين {0 و {1}} ."),
    max: jQuery.validator.format("ادخل قيمة أقل من أو تساوى {0}."),
    min: jQuery.validator.format("ادخل قيمة أقل من أو تساوى  {0}.")
});