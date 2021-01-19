/**
* Theme: Zircos Dashboard
* Author: Coderthemes
* Auto Complete
*/

/*jslint  browser: true, white: true, plusplus: true */
/*global $, countries */
var models = [], names = [];
var result = {};
$(function () {
    'use strict';

    //var countriesArray = $.map(countries, function (value, key) { return { value: value, data: key }; });

    //// Setup jQuery ajax mock:
    //$.mockjax({
    //    url: '*',
    //    responseTime: 2000,
    //    response: function (settings) {
    //        var query = settings.data.query,
    //            queryLowerCase = query.toLowerCase(),
    //            re = new RegExp('\\b' + $.Autocomplete.utils.escapeRegExChars(queryLowerCase), 'gi'),
    //            suggestions = $.grep(countriesArray, function (country) {
    //                 // return country.value.toLowerCase().indexOf(queryLowerCase) === 0;
    //                return re.test(country.value);
    //            }),
    //            response = {
    //                query: query,
    //                suggestions: suggestions
    //            };

    //        this.responseText = JSON.stringify(response);
    //    }
    //});


    // Initialize ajax autocomplete:
    if ($('input.autocomplete').length > 0) {
        $("input.autocomplete").each(function (key, input) {
            var url = $(this).data("url");

            $(input).autocomplete({
                serviceUrl: url,
                paramName: 'term',
                dataType: 'json',
                //type: 'POST',
                minChars: 2,
                lookupLimit: 20,
                transformResult: function (response) {
                    return {
                        suggestions: $.map(response, function (dataItem) {
                            return { value: dataItem.descripcion, data: dataItem.id };
                        })
                    };
                },

                lookupFilter: function (suggestion, originalQuery, queryLowerCase) {
                    var re = new RegExp('\\b' + $.Autocomplete.utils.escapeRegExChars(queryLowerCase), 'gi');
                    return re.test(suggestion.value);
                },
                onSelect: function (suggestion) {
                    $("input[id*='" + $(input).attr("id") + "_id']").val(suggestion.data);
                }
            });

        });
    }





});