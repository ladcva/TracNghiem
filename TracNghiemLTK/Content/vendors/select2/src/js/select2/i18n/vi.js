define(function () {
  // Vietnamese
  return {
    inputTooLong: function (args) {
      var overChars = args.input.length - args.maximum;

      var message = 'Please enter less than ' + overChars + ' characters';

      if (overChars != 1) {
        message += 's';
      }

      return message;
    },
    inputTooShort: function (args) {
      var remainingChars = args.minimum - args.input.length;

      var message = 'Please enter more than ' + remainingChars + ' characters"';

      return message;
    },
    loadingMore: function () {
      return 'Getting more result…';
    },
    maximumSelected: function (args) {
      var message = 'Can only choose ' + args.maximum + ' option';

      return message;
    },
    noResults: function () {
      return 'Not fount result';
    },
    searching: function () {
      return 'Finding…';
    }
  };
});
