/**
 * angular-bootstrap-calendar - A pure AngularJS bootstrap themed responsive calendar that can display events and has views for year, month, week and day
 * @version v0.15.0
 * @link https://github.com/mattlewis92/angular-bootstrap-calendar
 * @license MIT
 */
! function(e, t) {
    if ("object" == typeof exports && "object" == typeof module) module.exports = t(require("angular"), require("moment"), function() {
        try {
            return require("interact.js")
        } catch (e) {}
    }());
    else if ("function" == typeof define && define.amd) define(["angular", "moment", "interact"], t);
    else {
        var n = "object" == typeof exports ? t(require("angular"), require("moment"), function() {
            try {
                return require("interact.js")
            } catch (e) {}
        }()) : t(e.angular, e.moment, e.interact);
        for (var a in n)("object" == typeof exports ? exports : e)[a] = n[a]
    }
}(this, function(e, t, n) {
    return function(e) {
        function t(a) {
            if (n[a]) return n[a].exports;
            var r = n[a] = {
                exports: {},
                id: a,
                loaded: !1
            };
            return e[a].call(r.exports, r, r.exports, t), r.loaded = !0, r.exports
        }
        var n = {};
        return t.m = e, t.c = n, t.p = "", t(0)
    }([function(e, t, n) {
        "use strict";
        n(2), e.exports = n(28)
    }, function(t, n) {
        t.exports = e
    }, function(e, t) {}, function(e, t) {
        e.exports = '<div class=cal-context ng-switch=vm.view><div class="alert alert-danger" ng-switch-default>The value passed to the view attribute of the calendar is not set</div><div class="alert alert-danger" ng-hide=vm.currentDay>The value passed to current-day attribute of the calendar is not set</div><mwl-calendar-year events=vm.events current-day=vm.currentDay on-event-click=vm.onEventClick on-event-times-changed=vm.onEventTimesChanged on-edit-event-click=vm.onEditEventClick on-delete-event-click=vm.onDeleteEventClick on-timespan-click=vm.onTimespanClick edit-event-html=vm.editEventHtml delete-event-html=vm.deleteEventHtml auto-open=vm.autoOpen cell-modifier=vm.cellModifier ng-switch-when=year></mwl-calendar-year><mwl-calendar-month events=vm.events current-day=vm.currentDay on-event-click=vm.onEventClick on-event-times-changed=vm.onEventTimesChanged on-edit-event-click=vm.onEditEventClick on-delete-event-click=vm.onDeleteEventClick on-timespan-click=vm.onTimespanClick edit-event-html=vm.editEventHtml delete-event-html=vm.deleteEventHtml auto-open=vm.autoOpen cell-modifier=vm.cellModifier cell-template-url="{{ vm.monthCellTemplateUrl }}" cell-events-template-url="{{ vm.monthCellEventsTemplateUrl }}" ng-switch-when=month></mwl-calendar-month><mwl-calendar-week events=vm.events current-day=vm.currentDay on-event-click=vm.onEventClick on-event-times-changed=vm.onEventTimesChanged day-view-start=vm.dayViewStart day-view-end=vm.dayViewEnd day-view-split=vm.dayViewSplit ng-switch-when=week></mwl-calendar-week><mwl-calendar-day events=vm.events current-day=vm.currentDay on-event-click=vm.onEventClick on-event-times-changed=vm.onEventTimesChanged on-timespan-click=vm.onTimespanClick day-view-start=vm.dayViewStart day-view-end=vm.dayViewEnd day-view-split=vm.dayViewSplit ng-switch-when=day></mwl-calendar-day></div>'
    }, function(e, t) {
        e.exports = '<div class=cal-day-box><div class="row-fluid clearfix cal-row-head"><div class="span1 col-xs-1 cal-cell" ng-bind=vm.calendarConfig.i18nStrings.timeLabel></div><div class="span11 col-xs-11 cal-cell" ng-bind=vm.calendarConfig.i18nStrings.eventsLabel></div></div><div class="cal-day-panel clearfix" ng-style="{height: vm.dayViewHeight + \'px\'}"><mwl-calendar-hour-list day-view-start=vm.dayViewStart day-view-end=vm.dayViewEnd day-view-split=vm.dayViewSplit on-timespan-click=vm.onTimespanClick current-day=vm.currentDay></mwl-calendar-hour-list><div class="pull-left day-event day-highlight" ng-repeat="event in vm.view track by event.$id" ng-class="\'dh-event-\' + event.type + \' \' + event.cssClass" ng-style="{top: event.top + \'px\', left: event.left + 60 + \'px\', height: event.height + \'px\'}" mwl-draggable="event.draggable === true" axis="\'y\'" snap-grid="{y: 30}" on-drag="vm.eventDragged(event, y)" on-drag-end="vm.eventDragComplete(event, y)" mwl-resizable="event.resizable === true && event.endsAt" resize-edges="{top: true, bottom: true}" on-resize="vm.eventResized(event, edge, y)" on-resize-end="vm.eventResizeComplete(event, edge, y)"><span class=cal-hours><span ng-show="event.top == 0"><span ng-bind="(event.tempStartsAt || event.startsAt) | calendarDate:\'day\':true"></span>,</span> <span ng-bind="(event.tempStartsAt || event.startsAt) | calendarDate:\'time\':true"></span></span> <a href=javascript:; class=event-item ng-click="vm.onEventClick({calendarEvent: event})"><span ng-bind-html="vm.$sce.trustAsHtml(event.title) | calendarTruncateEventTitle:20:event.height"></span></a></div></div></div>'
    }, function(e, t) {
        e.exports = '<div class=cal-day-panel-hour><div class=cal-day-hour ng-repeat="hour in vm.hours track by $index"><div class="row-fluid cal-day-hour-part" ng-click="vm.onTimespanClick({calendarDate: hour.date.toDate()})"><div class="span1 col-xs-1"><strong ng-bind=hour.label></strong></div><div class="span11 col-xs-11"></div></div><div class="row-fluid cal-day-hour-part" ng-click="vm.onTimespanClick({calendarDate: hour.date.clone().add(vm.dayViewSplit, \'minutes\').toDate()})"><div class="span1 col-xs-1"></div><div class="span11 col-xs-11"></div></div><div class="row-fluid cal-day-hour-part" ng-show="vm.dayViewSplit < 30" ng-click="vm.onTimespanClick({calendarDate: hour.date.clone().add(vm.dayViewSplit * 2, \'minutes\').toDate()})"><div class="span1 col-xs-1"></div><div class="span11 col-xs-11"></div></div><div class="row-fluid cal-day-hour-part" ng-show="vm.dayViewSplit < 30" ng-click="vm.onTimespanClick({calendarDate: hour.date.clone().add(vm.dayViewSplit * 3, \'minutes\').toDate()})"><div class="span1 col-xs-1"></div><div class="span11 col-xs-11"></div></div><div class="row-fluid cal-day-hour-part" ng-show="vm.dayViewSplit < 15" ng-click="vm.onTimespanClick({calendarDate: hour.date.clone().add(vm.dayViewSplit * 4, \'minutes\').toDate()})"><div class="span1 col-xs-1"></div><div class="span11 col-xs-11"></div></div><div class="row-fluid cal-day-hour-part" ng-show="vm.dayViewSplit < 15" ng-click="vm.onTimespanClick({calendarDate: hour.date.clone().add(vm.dayViewSplit * 5, \'minutes\').toDate()})"><div class="span1 col-xs-1"></div><div class="span11 col-xs-11"></div></div></div></div>'
    }, function(e, t) {
        e.exports = '<div mwl-droppable on-drop="vm.handleEventDrop(dropData.event, day.date)" class="cal-month-day {{ day.cssClass }}" ng-class="{\n            \'cal-day-outmonth\': !day.inMonth,\n            \'cal-day-inmonth\': day.inMonth,\n            \'cal-day-weekend\': day.isWeekend,\n            \'cal-day-past\': day.isPast,\n            \'cal-day-today\': day.isToday,\n            \'cal-day-future\': day.isFuture\n          }"><small class="cal-events-num badge badge-important pull-left" ng-show="day.badgeTotal > 0" ng-bind=day.badgeTotal></small> <span class=pull-right data-cal-date ng-click=vm.calendarCtrl.drillDown(day.date) ng-bind=day.label></span><div class=cal-day-tick ng-show="dayIndex === vm.openDayIndex && vm.view[vm.openDayIndex].events.length > 0"><i class="glyphicon glyphicon-chevron-up"></i> <i class="fa fa-chevron-up"></i></div><ng-include src="vm.cellEventsTemplateUrl || \'calendarMonthCellEvents.html\'"></ng-include><div id=cal-week-box ng-if="$first && rowHovered">Week {{ day.date.week() }}</div></div>'
    }, function(e, t) {
        e.exports = '<div class=events-list ng-show="day.events.length > 0"><a ng-repeat="event in day.events | orderBy:\'startsAt\' track by event.$id" href=javascript:; ng-click="vm.onEventClick({calendarEvent: event})" class="pull-left event" ng-class="\'event-\' + event.type + \' \' + event.cssClass" ng-mouseenter="vm.highlightEvent(event, true)" ng-mouseleave="vm.highlightEvent(event, false)" tooltip-append-to-body=true tooltip-html-unsafe="{{ (event.startsAt | calendarDate:\'time\':true) + (vm.calendarConfig.displayEventEndTimes && event.endsAt ? \' - \' + (event.endsAt | calendarDate:\'time\':true) : \'\') + \' - \' + event.title }}" mwl-draggable="event.draggable === true" drop-data="{event: event}"></a></div>'
    }, function(e, t) {
        e.exports = '<div class="cal-row-fluid cal-row-head"><div class=cal-cell1 ng-repeat="day in vm.weekDays track by $index" ng-bind=day></div></div><div class=cal-month-box><div ng-repeat="rowOffset in vm.monthOffsets track by rowOffset" ng-mouseenter="rowHovered = true" ng-mouseleave="rowHovered = false"><div class="cal-row-fluid cal-before-eventlist"><div ng-repeat="day in vm.view | calendarLimitTo:7:rowOffset track by $index" ng-init="dayIndex = vm.view.indexOf(day)" class="cal-cell1 cal-cell {{ day.highlightClass }}" ng-click=vm.dayClicked(day) ng-class="{pointer: day.events.length > 0}"><ng-include src="vm.cellTemplateUrl || \'calendarMonthCell.html\'"></ng-include></div></div><mwl-calendar-slide-box is-open="vm.openRowIndex === $index && vm.view[vm.openDayIndex].events.length > 0" events=vm.view[vm.openDayIndex].events on-event-click=vm.onEventClick edit-event-html=vm.editEventHtml on-edit-event-click=vm.onEditEventClick delete-event-html=vm.deleteEventHtml on-delete-event-click=vm.onDeleteEventClick></mwl-calendar-slide-box></div></div>'
    }, function(e, t) {
        e.exports = '<div class=cal-slide-box collapse=vm.isCollapsed mwl-collapse-fallback=vm.isCollapsed><div class="cal-slide-content cal-event-list"><ul class="unstyled list-unstyled"><li ng-repeat="event in vm.events | orderBy:\'startsAt\' track by event.$id" ng-class=event.cssClass mwl-draggable="event.draggable === true" drop-data="{event: event}"><span class="pull-left event" ng-class="\'event-\' + event.type"></span> &nbsp; <a href=javascript:; class=event-item ng-click="vm.onEventClick({calendarEvent: event})"><span ng-bind-html=vm.$sce.trustAsHtml(event.title)></span> (<span ng-bind="event.startsAt | calendarDate:(isMonthView ? \'time\' : \'datetime\'):true"></span><span ng-if="vm.calendarConfig.displayEventEndTimes && event.endsAt">- <span ng-bind="event.endsAt | calendarDate:(isMonthView ? \'time\' : \'datetime\'):true"></span></span>)</a> <a href=javascript:; class=event-item-edit ng-if="vm.editEventHtml && event.editable !== false" ng-bind-html=vm.$sce.trustAsHtml(vm.editEventHtml) ng-click="vm.onEditEventClick({calendarEvent: event})"></a> <a href=javascript:; class=event-item-delete ng-if="vm.deleteEventHtml && event.deletable !== false" ng-bind-html=vm.$sce.trustAsHtml(vm.deleteEventHtml) ng-click="vm.onDeleteEventClick({calendarEvent: event})"></a></li></ul></div></div>'
    }, function(e, t) {
        e.exports = '<div class=cal-week-box ng-class="{\'cal-day-box\': vm.showTimes}"><div class="cal-row-fluid cal-row-head"><div class=cal-cell1 ng-repeat="day in vm.view.days track by $index" ng-class="{\n        \'cal-day-weekend\': day.isWeekend,\n        \'cal-day-past\': day.isPast,\n        \'cal-day-today\': day.isToday,\n        \'cal-day-future\': day.isFuture}" mwl-element-dimensions=vm.dayColumnDimensions><span ng-bind=day.weekDayLabel></span><br><small><span data-cal-date ng-click=vm.calendarCtrl.drillDown(day.date) class=pointer ng-bind=day.dayLabel></span></small></div></div><div class="cal-day-panel clearfix" ng-style="{height: vm.showTimes ? (vm.dayViewHeight + \'px\') : \'auto\'}"><mwl-calendar-hour-list day-view-start=vm.dayViewStart day-view-end=vm.dayViewEnd day-view-split=vm.dayViewSplit current-day=vm.currentDay ng-if=vm.showTimes></mwl-calendar-hour-list><div class=row><div class=col-xs-12><div class=cal-row-fluid ng-repeat="event in vm.view.events track by event.$id"><div ng-class="\'cal-cell\' + (vm.showTimes ? 1 : event.daySpan) + \' cal-offset\' + event.dayOffset + \' day-highlight dh-event-\' + event.type + \' \' + event.cssClass" ng-style="{top: vm.showTimes ? ((event.top + 2) + \'px\') : \'auto\', position: vm.showTimes ? \'absolute\' : \'inherit\'}" data-event-class mwl-draggable="event.draggable === true" axis="vm.showTimes ? \'xy\' : \'x\'" snap-grid="vm.showTimes ? {x: vm.dayColumnDimensions.width, y: 30} : {x: vm.dayColumnDimensions.width}" on-drag="vm.tempTimeChanged(event, y)" on-drag-end="vm.weekDragged(event, x, y)" mwl-resizable="event.resizable === true && event.endsAt && !vm.showTimes" resize-edges="{left: true, right: true}" on-resize-end="vm.weekResized(event, edge, x)"><strong ng-bind="(event.tempStartsAt || event.startsAt) | calendarDate:\'time\':true" ng-show=vm.showTimes></strong> <a href=javascript:; ng-click="vm.onEventClick({calendarEvent: event})" class=event-item ng-bind-html=vm.$sce.trustAsHtml(event.title) tooltip-html-unsafe="{{ event.title }}" tooltip-placement=left tooltip-append-to-body=true></a></div></div></div></div></div></div>'
    }, function(e, t) {
        e.exports = '<div class=cal-year-box><div ng-repeat="rowOffset in [0, 4, 8] track by rowOffset"><div class="row cal-before-eventlist"><div class="span3 col-md-3 col-xs-6 cal-cell {{ day.cssClass }}" ng-repeat="month in vm.view | calendarLimitTo:4:rowOffset track by $index" ng-init="monthIndex = vm.view.indexOf(month)" ng-click=vm.monthClicked(month) ng-class="{pointer: month.events.length > 0, \'cal-day-today\': month.isToday}" mwl-droppable on-drop="vm.handleEventDrop(dropData.event, month.date)"><span class=pull-right data-cal-date ng-click=vm.calendarCtrl.drillDown(month.date) ng-bind=month.label></span> <small class="cal-events-num badge badge-important pull-left" ng-show="month.badgeTotal > 0" ng-bind=month.badgeTotal></small><div class=cal-day-tick ng-show="monthIndex === vm.openMonthIndex && vm.view[vm.openMonthIndex].events.length > 0"><i class="glyphicon glyphicon-chevron-up"></i> <i class="fa fa-chevron-up"></i></div></div></div><mwl-calendar-slide-box is-open="vm.openRowIndex === $index && vm.view[vm.openMonthIndex].events.length > 0" events=vm.view[vm.openMonthIndex].events on-event-click=vm.onEventClick edit-event-html=vm.editEventHtml on-edit-event-click=vm.onEditEventClick delete-event-html=vm.deleteEventHtml on-delete-event-click=vm.onDeleteEventClick></mwl-calendar-slide-box></div></div>'
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCalendarCtrl", ["$scope", "$log", "$timeout", "$attrs", "$locale", "moment", "calendarTitle", function(e, t, n, r, i, l, s) {
            function d(e) {
                return e.startsAt || t.warn("Bootstrap calendar: ", "Event is missing the startsAt field", e), a.isDate(e.startsAt) || t.warn("Bootstrap calendar: ", "Event startsAt should be a javascript date object", e), a.isDefined(e.endsAt) && (a.isDate(e.endsAt) || t.warn("Bootstrap calendar: ", "Event endsAt should be a javascript date object", e), l(e.startsAt).isAfter(l(e.endsAt)) && t.warn("Bootstrap calendar: ", "Event cannot start after it finishes", e)), !0
            }

            function o() {
                s[c.view] && a.isDefined(r.viewTitle) && (c.viewTitle = s[c.view](c.currentDay)), c.events = c.events.filter(d).map(function(e, t) {
                    return Object.defineProperty(e, "$id", {
                        enumerable: !1,
                        configurable: !0,
                        value: t
                    }), e
                });
                var t = l(c.currentDay),
                    i = !0;
                v.clone().startOf(c.view).isSame(t.clone().startOf(c.view)) && !v.isSame(t) && c.view === m && (i = !1), v = t, m = c.view, i && n(function() {
                    e.$broadcast("calendar.refreshView")
                })
            }
            var c = this;
            c.events = c.events || [], c.changeView = function(e, t) {
                c.view = e, c.currentDay = t
            }, c.drillDown = function(e) {
                var t = l(e).toDate(),
                    n = {
                        year: "month",
                        month: "day",
                        week: "day"
                    };
                c.onDrillDownClick({
                    calendarDate: t,
                    calendarNextView: n[c.view]
                }) !== !1 && c.changeView(n[c.view], t)
            };
            var v = l(c.currentDay),
                m = c.view,
                u = !1;
            e.$watchGroup(["vm.currentDay", "vm.view", function() {
                return l.locale() + i.id
            }], function() {
                u ? o() : (u = !0, e.$watch("vm.events", o, !0))
            })
        }]).directive("mwlCalendar", ["calendarUseTemplates", function(e) {
            return {
                template: e ? n(3) : "",
                restrict: "EA",
                scope: {
                    events: "=",
                    view: "=",
                    viewTitle: "=?",
                    currentDay: "=",
                    editEventHtml: "=",
                    deleteEventHtml: "=",
                    autoOpen: "=",
                    onEventClick: "&",
                    onEventTimesChanged: "&",
                    onEditEventClick: "&",
                    onDeleteEventClick: "&",
                    onTimespanClick: "&",
                    onDrillDownClick: "&",
                    cellModifier: "&",
                    dayViewStart: "@",
                    dayViewEnd: "@",
                    dayViewSplit: "@",
                    monthCellTemplateUrl: "@",
                    monthCellEventsTemplateUrl: "@"
                },
                controller: "MwlCalendarCtrl as vm",
                bindToController: !0
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCalendarDayCtrl", ["$scope", "$sce", "moment", "calendarHelper", "calendarConfig", function(e, t, n, a, r) {
            var i = this;
            i.calendarConfig = r, i.$sce = t, e.$on("calendar.refreshView", function() {
                i.dayViewSplit = i.dayViewSplit || 30, i.dayViewHeight = a.getDayViewHeight(i.dayViewStart, i.dayViewEnd, i.dayViewSplit), i.view = a.getDayView(i.events, i.currentDay, i.dayViewStart, i.dayViewEnd, i.dayViewSplit)
            }), i.eventDragComplete = function(e, t) {
                var a = t * i.dayViewSplit,
                    r = n(e.startsAt).add(a, "minutes"),
                    l = n(e.endsAt).add(a, "minutes");
                delete e.tempStartsAt, i.onEventTimesChanged({
                    calendarEvent: e,
                    calendarNewEventStart: r.toDate(),
                    calendarNewEventEnd: e.endsAt ? l.toDate() : null
                })
            }, i.eventDragged = function(e, t) {
                var a = t * i.dayViewSplit;
                e.tempStartsAt = n(e.startsAt).add(a, "minutes").toDate()
            }, i.eventResizeComplete = function(e, t, a) {
                var r = a * i.dayViewSplit,
                    l = n(e.startsAt),
                    s = n(e.endsAt);
                "start" === t ? l.add(r, "minutes") : s.add(r, "minutes"), delete e.tempStartsAt, i.onEventTimesChanged({
                    calendarEvent: e,
                    calendarNewEventStart: l.toDate(),
                    calendarNewEventEnd: s.toDate()
                })
            }, i.eventResized = function(e, t, a) {
                var r = a * i.dayViewSplit;
                "start" === t && (e.tempStartsAt = n(e.startsAt).add(r, "minutes").toDate())
            }
        }]).directive("mwlCalendarDay", ["calendarUseTemplates", function(e) {
            return {
                template: e ? n(4) : "",
                restrict: "EA",
                require: "^mwlCalendar",
                scope: {
                    events: "=",
                    currentDay: "=",
                    onEventClick: "=",
                    onEventTimesChanged: "=",
                    onTimespanClick: "=",
                    dayViewStart: "=",
                    dayViewEnd: "=",
                    dayViewSplit: "="
                },
                controller: "MwlCalendarDayCtrl as vm",
                bindToController: !0
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCalendarHourListCtrl", ["$scope", "moment", "calendarConfig", "calendarHelper", function(e, t, n, a) {
            function r() {
                i = t(s.dayViewStart || "00:00", "HH:mm"), l = t(s.dayViewEnd || "23:00", "HH:mm"), s.dayViewSplit = parseInt(s.dayViewSplit), s.hours = [];
                for (var e = t(s.currentDay).clone().hours(i.hours()).minutes(i.minutes()).seconds(i.seconds()), r = 0; r <= l.diff(i, "hours"); r++) s.hours.push({
                    label: a.formatDate(e, n.dateFormats.hour),
                    date: e.clone()
                }), e.add(1, "hour")
            }
            var i, l, s = this,
                d = t.locale();
            e.$on("calendar.refreshView", function() {
                d !== t.locale() && (d = t.locale(), r())
            }), e.$watchGroup(["vm.dayViewStart", "vm.dayViewEnd", "vm.dayViewSplit", "vm.currentDay"], function() {
                r()
            })
        }]).directive("mwlCalendarHourList", ["calendarUseTemplates", function(e) {
            return {
                restrict: "EA",
                template: e ? n(5) : "",
                controller: "MwlCalendarHourListCtrl as vm",
                scope: {
                    currentDay: "=",
                    dayViewStart: "=",
                    dayViewEnd: "=",
                    dayViewSplit: "=",
                    onTimespanClick: "="
                },
                bindToController: !0
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCalendarMonthCtrl", ["$scope", "moment", "calendarHelper", "calendarConfig", function(e, t, n, a) {
            var r = this;
            r.calendarConfig = a, e.$on("calendar.refreshView", function() {
                r.weekDays = n.getWeekDayNames(), r.view = n.getMonthView(r.events, r.currentDay, r.cellModifier);
                var e = Math.floor(r.view.length / 7);
                r.monthOffsets = [];
                for (var a = 0; e > a; a++) r.monthOffsets.push(7 * a);
                r.autoOpen && r.view.forEach(function(e) {
                    e.inMonth && t(r.currentDay).startOf("day").isSame(e.date) && !r.openDayIndex && r.dayClicked(e, !0)
                })
            }), r.dayClicked = function(e, t) {
                t || r.onTimespanClick({
                    calendarDate: e.date.toDate()
                }), r.openRowIndex = null;
                var n = r.view.indexOf(e);
                n === r.openDayIndex ? r.openDayIndex = null : (r.openDayIndex = n, r.openRowIndex = Math.floor(n / 7))
            }, r.highlightEvent = function(e, t) {
                r.view.forEach(function(n) {
                    if (delete n.highlightClass, t) {
                        var a = n.events.indexOf(e) > -1;
                        a && (n.highlightClass = "day-highlight dh-event-" + e.type)
                    }
                })
            }, r.handleEventDrop = function(e, a) {
                var i = t(e.startsAt).date(t(a).date()).month(t(a).month()),
                    l = n.adjustEndDateFromStartDiff(e.startsAt, i, e.endsAt);
                r.onEventTimesChanged({
                    calendarEvent: e,
                    calendarDate: a,
                    calendarNewEventStart: i.toDate(),
                    calendarNewEventEnd: l ? l.toDate() : null
                })
            }
        }]).directive("mwlCalendarMonth", ["calendarUseTemplates", function(e) {
            return {
                template: e ? n(8) : "",
                restrict: "EA",
                require: "^mwlCalendar",
                scope: {
                    events: "=",
                    currentDay: "=",
                    onEventClick: "=",
                    onEditEventClick: "=",
                    onDeleteEventClick: "=",
                    onEventTimesChanged: "=",
                    editEventHtml: "=",
                    deleteEventHtml: "=",
                    autoOpen: "=",
                    onTimespanClick: "=",
                    cellModifier: "=",
                    cellTemplateUrl: "@",
                    cellEventsTemplateUrl: "@"
                },
                controller: "MwlCalendarMonthCtrl as vm",
                link: function(e, t, n, a) {
                    e.vm.calendarCtrl = a
                },
                bindToController: !0
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCalendarSlideBoxCtrl", ["$sce", "$scope", "$timeout", "calendarConfig", function(e, t, n, a) {
            var r = this;
            r.$sce = e, r.calendarConfig = a, r.isCollapsed = !0, t.$watch("vm.isOpen", function(e) {
                n(function() {
                    r.isCollapsed = !e
                })
            })
        }]).directive("mwlCalendarSlideBox", ["calendarUseTemplates", function(e) {
            return {
                restrict: "EA",
                template: e ? n(9) : "",
                replace: !0,
                controller: "MwlCalendarSlideBoxCtrl as vm",
                require: ["^?mwlCalendarMonth", "^?mwlCalendarYear"],
                link: function(e, t, n, a) {
                    e.isMonthView = !!a[0], e.isYearView = !!a[1]
                },
                scope: {
                    isOpen: "=",
                    events: "=",
                    onEventClick: "=",
                    editEventHtml: "=",
                    onEditEventClick: "=",
                    deleteEventHtml: "=",
                    onDeleteEventClick: "="
                },
                bindToController: !0
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCalendarWeekCtrl", ["$scope", "$sce", "moment", "calendarHelper", "calendarConfig", function(e, t, n, a, r) {
            var i = this;
            i.showTimes = r.showTimesOnWeekView, i.$sce = t, e.$on("calendar.refreshView", function() {
                i.dayViewSplit = i.dayViewSplit || 30, i.dayViewHeight = a.getDayViewHeight(i.dayViewStart, i.dayViewEnd, i.dayViewSplit), i.showTimes ? i.view = a.getWeekViewWithTimes(i.events, i.currentDay, i.dayViewStart, i.dayViewEnd, i.dayViewSplit) : i.view = a.getWeekView(i.events, i.currentDay)
            }), i.weekDragged = function(e, t, a) {
                var r = n(e.startsAt).add(t, "days"),
                    l = n(e.endsAt).add(t, "days");
                if (a) {
                    var s = a * i.dayViewSplit;
                    r = r.add(s, "minutes"), l = l.add(s, "minutes")
                }
                delete e.tempStartsAt, i.onEventTimesChanged({
                    calendarEvent: e,
                    calendarNewEventStart: r.toDate(),
                    calendarNewEventEnd: e.endsAt ? l.toDate() : null
                })
            }, i.weekResized = function(e, t, a) {
                var r = n(e.startsAt),
                    l = n(e.endsAt);
                "start" === t ? r.add(a, "days") : l.add(a, "days"), i.onEventTimesChanged({
                    calendarEvent: e,
                    calendarNewEventStart: r.toDate(),
                    calendarNewEventEnd: l.toDate()
                })
            }, i.tempTimeChanged = function(e, t) {
                var a = t * i.dayViewSplit;
                e.tempStartsAt = n(e.startsAt).add(a, "minutes").toDate()
            }
        }]).directive("mwlCalendarWeek", ["calendarUseTemplates", function(e) {
            return {
                template: e ? n(10) : "",
                restrict: "EA",
                require: "^mwlCalendar",
                scope: {
                    events: "=",
                    currentDay: "=",
                    onEventClick: "=",
                    onEventTimesChanged: "=",
                    dayViewStart: "=",
                    dayViewEnd: "=",
                    dayViewSplit: "="
                },
                controller: "MwlCalendarWeekCtrl as vm",
                link: function(e, t, n, a) {
                    e.vm.calendarCtrl = a
                },
                bindToController: !0
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCalendarYearCtrl", ["$scope", "moment", "calendarHelper", function(e, t, n) {
            var a = this;
            e.$on("calendar.refreshView", function() {
                a.view = n.getYearView(a.events, a.currentDay, a.cellModifier), a.autoOpen && a.view.forEach(function(e) {
                    t(a.currentDay).startOf("month").isSame(e.date) && !a.openMonthIndex && a.monthClicked(e, !0)
                })
            }), a.monthClicked = function(e, t) {
                t || a.onTimespanClick({
                    calendarDate: e.date.toDate()
                }), a.openRowIndex = null;
                var n = a.view.indexOf(e);
                n === a.openMonthIndex ? a.openMonthIndex = null : (a.openMonthIndex = n, a.openRowIndex = Math.floor(n / 4))
            }, a.handleEventDrop = function(e, r) {
                var i = t(e.startsAt).month(t(r).month()),
                    l = n.adjustEndDateFromStartDiff(e.startsAt, i, e.endsAt);
                a.onEventTimesChanged({
                    calendarEvent: e,
                    calendarDate: r,
                    calendarNewEventStart: i.toDate(),
                    calendarNewEventEnd: l ? l.toDate() : null
                })
            }
        }]).directive("mwlCalendarYear", ["calendarUseTemplates", function(e) {
            return {
                template: e ? n(11) : "",
                restrict: "EA",
                require: "^mwlCalendar",
                scope: {
                    events: "=",
                    currentDay: "=",
                    onEventClick: "=",
                    onEventTimesChanged: "=",
                    onEditEventClick: "=",
                    onDeleteEventClick: "=",
                    editEventHtml: "=",
                    deleteEventHtml: "=",
                    autoOpen: "=",
                    onTimespanClick: "=",
                    cellModifier: "="
                },
                controller: "MwlCalendarYearCtrl as vm",
                link: function(e, t, n, a) {
                    e.vm.calendarCtrl = a
                },
                bindToController: !0
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlCollapseFallbackCtrl", ["$scope", "$attrs", "$element", function(e, t, n) {
            e.$watch(t.mwlCollapseFallback, function(e) {
                e ? n.addClass("ng-hide") : n.removeClass("ng-hide")
            })
        }]).directive("mwlCollapseFallback", ["$injector", function(e) {
            return e.has("collapseDirective") ? {} : {
                restrict: "A",
                controller: "MwlCollapseFallbackCtrl"
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlDateModifierCtrl", ["$element", "$attrs", "$scope", "moment", function(e, t, n, r) {
            function i() {
                a.isDefined(t.setToToday) ? l.date = new Date : a.isDefined(t.increment) ? l.date = r(l.date).add(1, l.increment).toDate() : a.isDefined(t.decrement) && (l.date = r(l.date).subtract(1, l.decrement).toDate()), n.$apply()
            }
            var l = this;
            e.bind("click", i), n.$on("$destroy", function() {
                e.unbind("click", i)
            })
        }]).directive("mwlDateModifier", function() {
            return {
                restrict: "A",
                controller: "MwlDateModifierCtrl as vm",
                scope: {
                    date: "=",
                    increment: "=",
                    decrement: "="
                },
                bindToController: !0
            }
        })
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlDraggableCtrl", ["$element", "$scope", "$window", "$parse", "$attrs", "interact", function(e, t, n, r, i, l) {
            function s(e, t) {
                return e.css("-ms-transform", t).css("-webkit-transform", t).css("transform", t)
            }

            function d() {
                return r(i.mwlDraggable)(t)
            }

            function o(e, t, n) {
                var a = {
                    x: e,
                    y: t
                };
                return n && n.x && (a.x /= n.x), n && n.y && (a.y /= n.y), a
            }
            if (l) {
                var c, v;
                i.snapGrid && (v = r(i.snapGrid)(t), c = {
                    targets: [l.createSnapGrid(v)]
                }), l(e[0]).draggable({
                    snap: c,
                    onstart: function(e) {
                        d() && (a.element(e.target).addClass("dragging-active"), e.target.dropData = r(i.dropData)(t), e.target.style.pointerEvents = "none", i.onDragStart && (r(i.onDragStart)(t), t.$apply()))
                    },
                    onmove: function(e) {
                        if (d()) {
                            var l = a.element(e.target),
                                c = (parseFloat(l.attr("data-x")) || 0) + (e.dx || 0),
                                m = (parseFloat(l.attr("data-y")) || 0) + (e.dy || 0);
                            switch (r(i.axis)(t)) {
                                case "x":
                                    m = 0;
                                    break;
                                case "y":
                                    c = 0
                            }
                            "static" === n.getComputedStyle(l[0]).position && l.css("position", "relative"), s(l, "translate(" + c + "px, " + m + "px)").css("z-index", 1e3).attr("data-x", c).attr("data-y", m), i.onDrag && (r(i.onDrag)(t, o(c, m, v)), t.$apply())
                        }
                    },
                    onend: function(e) {
                        if (d()) {
                            var n = a.element(e.target),
                                l = n.attr("data-x"),
                                c = n.attr("data-y");
                            e.target.style.pointerEvents = "auto", i.onDragEnd && (r(i.onDragEnd)(t, o(l, c, v)), t.$apply()), s(n, "").removeAttr("data-x").removeAttr("data-y").removeClass("dragging-active")
                        }
                    }
                }), t.$on("$destroy", function() {
                    l(e[0]).unset()
                })
            }
        }]).directive("mwlDraggable", function() {
            return {
                restrict: "A",
                controller: "MwlDraggableCtrl"
            }
        })
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlDroppableCtrl", ["$element", "$scope", "$parse", "$attrs", "interact", function(e, t, n, r, i) {
            i && (i(e[0]).dropzone({
                ondragenter: function(e) {
                    a.element(e.target).addClass("drop-active")
                },
                ondragleave: function(e) {
                    a.element(e.target).removeClass("drop-active")
                },
                ondropdeactivate: function(e) {
                    a.element(e.target).removeClass("drop-active")
                },
                ondrop: function(e) {
                    e.relatedTarget.dropData && (n(r.onDrop)(t, {
                        dropData: e.relatedTarget.dropData
                    }), t.$apply())
                }
            }), t.$on("$destroy", function() {
                i(e[0]).unset()
            }))
        }]).directive("mwlDroppable", function() {
            return {
                restrict: "A",
                controller: "MwlDroppableCtrl"
            }
        })
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlElementDimensionsCtrl", ["$element", "$scope", "$parse", "$attrs", function(e, t, n, a) {
            n(a.mwlElementDimensions).assign(t, {
                width: e[0].offsetWidth,
                height: e[0].offsetHeight
            })
        }]).directive("mwlElementDimensions", function() {
            return {
                restrict: "A",
                controller: "MwlElementDimensionsCtrl"
            }
        })
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").controller("MwlResizableCtrl", ["$element", "$scope", "$parse", "$attrs", "interact", function(e, t, n, r, i) {
            function l() {
                return n(r.mwlResizable)(t)
            }

            function s(e, t, n) {
                var a = {};
                return a.edge = e, "start" === e ? (a.x = t.data("x"), a.y = t.data("y")) : "end" === e && (a.x = parseFloat(t.css("width").replace("px", "")) - v.width, a.y = parseFloat(t.css("height").replace("px", "")) - v.height), n && n.x && (a.x = Math.round(a.x / n.x)), n && n.y && (a.y = Math.round(a.y / n.y)), a
            }
            if (i) {
                var d, o;
                r.snapGrid && (o = n(r.snapGrid)(t), d = {
                    targets: [i.createSnapGrid(o)]
                });
                var c, v = {},
                    m = {};
                i(e[0]).resizable({
                    edges: n(r.resizeEdges)(t),
                    snap: d,
                    onstart: function(e) {
                        if (l()) {
                            c = "end";
                            var t = a.element(e.target);
                            v.height = t[0].offsetHeight, v.width = t[0].offsetWidth, m.height = t.css("height"), m.width = t.css("width")
                        }
                    },
                    onmove: function(e) {
                        if (l()) {
                            var i = a.element(e.target),
                                d = parseFloat(i.data("x") || 0),
                                v = parseFloat(i.data("y") || 0);
                            i.css({
                                width: e.rect.width + "px",
                                height: e.rect.height + "px"
                            }), d += e.deltaRect.left, v += e.deltaRect.top, i.css("transform", "translate(" + d + "px," + v + "px)"), i.data("x", d), i.data("y", v), (0 !== e.deltaRect.left || 0 !== e.deltaRect.top) && (c = "start"), r.onResize && (n(r.onResize)(t, s(c, i, o)), t.$apply())
                        }
                    },
                    onend: function(e) {
                        if (l()) {
                            var i = a.element(e.target),
                                d = s(c, i, o);
                            i.data("x", null).data("y", null).css({
                                transform: "",
                                width: m.width,
                                height: m.height
                            }), r.onResizeEnd && (n(r.onResizeEnd)(t, d), t.$apply())
                        }
                    }
                }), t.$on("$destroy", function() {
                    i(e[0]).unset()
                })
            }
        }]).directive("mwlResizable", function() {
            return {
                restrict: "A",
                controller: "MwlResizableCtrl"
            }
        })
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").filter("calendarDate", ["calendarHelper", "calendarConfig", function(e, t) {
            function n(n, a, r) {
                return r === !0 && (a = t.dateFormats[a]), e.formatDate(n, a)
            }
            return n.$stateful = !0, n
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").filter("calendarLimitTo", ["limitToFilter", function(e) {
            return a.version.minor >= 4 ? e : function(e, t, n) {
                return t = Math.abs(Number(t)) === 1 / 0 ? Number(t) : parseInt(t), isNaN(t) ? e : (a.isNumber(e) && (e = e.toString()), a.isArray(e) || a.isString(e) ? (n = !n || isNaN(n) ? 0 : parseInt(n), n = 0 > n && n >= -e.length ? e.length + n : n, t >= 0 ? e.slice(n, n + t) : 0 === n ? e.slice(t, e.length) : e.slice(Math.max(0, n + t), n)) : e)
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").filter("calendarTruncateEventTitle", function() {
            return function(e, t, n) {
                return e ? e.length >= t && e.length / 20 > n / 30 ? e.substr(0, t) + "..." : e : ""
            }
        })
    }, function(e, t, n) {
        "use strict";

        function a(e) {
            e.keys().forEach(e)
        }
        var r = n(1);
        e.exports = r.module("mwl.calendar", []).constant("calendarUseTemplates", !0).run(["$templateCache", "calendarUseTemplates", function(e, t) {
            t && (e.put("calendarMonthCellEvents.html", n(7)), e.put("calendarMonthCell.html", n(6)))
        }]).name, a(n(34)), a(n(35)), a(n(36))
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").provider("calendarConfig", function() {
            var e = {
                    angular: {
                        date: {
                            hour: "ha",
                            day: "d MMM",
                            month: "MMMM",
                            weekDay: "EEEE",
                            time: "HH:mm",
                            datetime: "MMM d, h:mm a"
                        },
                        title: {
                            day: "EEEE d MMMM, yyyy",
                            week: "Week {week} of {year}",
                            month: "MMMM yyyy",
                            year: "yyyy"
                        }
                    },
                    moment: {
                        date: {
                            hour: "ha",
                            day: "D MMM",
                            month: "MMMM",
                            weekDay: "dddd",
                            time: "HH:mm",
                            datetime: "MMM D, h:mm a"
                        },
                        title: {
                            day: "dddd D MMMM, YYYY",
                            week: "Week {week} of {year}",
                            month: "MMMM YYYY",
                            year: "YYYY"
                        }
                    }
                },
                t = "angular",
                n = a.copy(e[t].date),
                r = a.copy(e[t].title),
                i = !1,
                l = !1,
                s = !1,
                d = {
                    eventsLabel: "Events",
                    timeLabel: "Time"
                },
                o = this;
            o.setDateFormats = function(e) {
                return a.extend(n, e), o
            }, o.setTitleFormats = function(e) {
                return a.extend(r, e), o
            }, o.setI18nStrings = function(e) {
                return a.extend(d, e), o
            }, o.setDisplayAllMonthEvents = function(e) {
                return s = e, o
            }, o.setDisplayEventEndTimes = function(e) {
                return i = e, o
            }, o.setDateFormatter = function(i) {
                if (-1 === ["angular", "moment"].indexOf(i)) throw new Error("Invalid date formatter. Allowed types are angular and moment.");
                return t = i, n = a.copy(e[t].date), r = a.copy(e[t].title), o
            }, o.showTimesOnWeekView = function(e) {
                return l = e, o
            }, o.$get = function() {
                return {
                    dateFormats: n,
                    titleFormats: r,
                    i18nStrings: d,
                    displayAllMonthEvents: s,
                    displayEventEndTimes: i,
                    dateFormatter: t,
                    showTimesOnWeekView: l
                }
            }
        })
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").factory("calendarHelper", ["dateFilter", "moment", "calendarConfig", function(e, t, n) {
            function r(a, r) {
                return "angular" === n.dateFormatter ? e(t(a).toDate(), r) : "moment" === n.dateFormatter ? t(a).format(r) : void 0
            }

            function i(e, n, a) {
                if (!a) return a;
                var r = t(n).diff(t(e));
                return t(a).add(r)
            }

            function l(e, n, r) {
                var l = t(e.startsAt),
                    s = t(e.endsAt || e.startsAt);
                if (n = t(n), r = t(r), a.isDefined(e.recursOn)) {
                    switch (e.recursOn) {
                        case "year":
                            l.set({
                                year: n.year()
                            });
                            break;
                        case "month":
                            l.set({
                                year: n.year(),
                                month: n.month()
                            });
                            break;
                        default:
                            throw new Error("Invalid value (" + e.recursOn + ") given for recurs on. Can only be year or month.")
                    }
                    s = i(e.startsAt, l, s)
                }
                return l.isAfter(n) && l.isBefore(r) || s.isAfter(n) && s.isBefore(r) || l.isBefore(n) && s.isAfter(r) || l.isSame(n) || s.isSame(r)
            }

            function s(e, t, n) {
                return e.filter(function(e) {
                    return l(e, t, n)
                })
            }

            function d(e, n, a) {
                var r = t(e).startOf(n),
                    i = t(e).endOf(n);
                return s(a, r, i)
            }

            function o(e) {
                return e.filter(function(e) {
                    return e.incrementsBadgeTotal !== !1;
                }).length
            }

            function c() {
                for (var e = [], a = 0; 7 > a;) e.push(r(t().weekday(a++), n.dateFormats.weekDay));
                return e
            }

            function v(e, a, i) {
                for (var l = [], c = d(a, "year", e), v = t(a).startOf("year"), m = 0; 12 > m;) {
                    var u = v.clone(),
                        f = u.clone().endOf("month"),
                        p = s(c, u, f),
                        w = {
                            label: r(u, n.dateFormats.month),
                            isToday: u.isSame(t().startOf("month")),
                            events: p,
                            date: u,
                            badgeTotal: o(p)
                        };
                    i({
                        calendarCell: w
                    }), l.push(w), v.add(1, "month"), m++
                }
                return l
            }

            function m(e, a, r) {
                var i, l = t(a).startOf("month"),
                    d = l.clone().startOf("week"),
                    c = t(a).endOf("month").endOf("week");
                i = n.displayAllMonthEvents ? s(e, d, c) : s(e, l, l.clone().endOf("month"));
                for (var v = [], m = t().startOf("day"); d.isBefore(c);) {
                    var u = d.month() === t(a).month(),
                        f = [];
                    (u || n.displayAllMonthEvents) && (f = s(i, d, d.clone().endOf("day")));
                    var p = {
                        label: d.date(),
                        date: d.clone(),
                        inMonth: u,
                        isPast: m.isAfter(d),
                        isToday: m.isSame(d),
                        isFuture: m.isBefore(d),
                        isWeekend: [0, 6].indexOf(d.day()) > -1,
                        events: f,
                        badgeTotal: o(f)
                    };
                    r({
                        calendarCell: p
                    }), v.push(p), d.add(1, "day")
                }
                return v
            }

            function u(e, a) {
                for (var i = t(a).startOf("week"), l = t(a).endOf("week"), d = i.clone(), o = [], c = t().startOf("day"); o.length < 7;) o.push({
                    weekDayLabel: r(d, n.dateFormats.weekDay),
                    date: d.clone(),
                    dayLabel: r(d, n.dateFormats.day),
                    isPast: d.isBefore(c),
                    isToday: d.isSame(c),
                    isFuture: d.isAfter(c),
                    isWeekend: [0, 6].indexOf(d.day()) > -1
                }), d.add(1, "day");
                var v = s(e, i, l).map(function(e) {
                    var n, a, r = t(e.startsAt).startOf("day"),
                        s = t(e.endsAt || e.startsAt).startOf("day"),
                        d = t(i).startOf("day"),
                        o = t(l).startOf("day");
                    return n = r.isBefore(d) || r.isSame(d) ? 0 : r.diff(d, "days"), s.isAfter(o) && (s = o), r.isBefore(d) && (r = d), a = t(s).diff(r, "days") + 1, e.daySpan = a, e.dayOffset = n, e
                });
                return {
                    days: o,
                    events: v
                }
            }

            function f(e, n, a, r, i) {
                var d = t(a || "00:00", "HH:mm").hours(),
                    o = t(r || "23:00", "HH:mm").hours(),
                    c = 60 / i * 30,
                    v = t(n).startOf("day").add(d, "hours"),
                    m = t(n).startOf("day").add(o, "hours"),
                    u = (o - d + 1) * c,
                    f = c / 60,
                    p = [],
                    w = s(e, t(n).startOf("day").toDate(), t(n).endOf("day").toDate());
                return w.map(function(e) {
                    if (t(e.startsAt).isBefore(v) ? e.top = 0 : e.top = t(e.startsAt).startOf("minute").diff(v.startOf("minute"), "minutes") * f - 2, t(e.endsAt || e.startsAt).isAfter(m)) e.height = u - e.top;
                    else {
                        var n = e.startsAt;
                        t(e.startsAt).isBefore(v) && (n = v.toDate()), e.endsAt ? e.height = t(e.endsAt || e.startsAt).diff(n, "minutes") * f : e.height = 30
                    }
                    return e.top - e.height > u && (e.height = 0), e.left = 0, e
                }).filter(function(e) {
                    return e.height > 0
                }).map(function(e) {
                    var t = !0;
                    return p.forEach(function(n, a) {
                        var r = !0;
                        n.forEach(function(t) {
                            (l(e, t.startsAt, t.endsAt || t.startsAt) || l(t, e.startsAt, e.endsAt || e.startsAt)) && (r = !1)
                        }), r && t && (t = !1, e.left = 150 * a, p[a].push(e))
                    }), t && (e.left = 150 * p.length, p.push([e])), e
                })
            }

            function p(e, n, a, r, i) {
                var l = u(e, n),
                    s = [];
                return l.days.forEach(function(e) {
                    var n = l.events.filter(function(n) {
                            return t(n.startsAt).startOf("day").isSame(t(e.date).startOf("day"))
                        }),
                        d = f(n, e.date, a, r, i);
                    s = s.concat(d)
                }), l.events = s, l
            }

            function w(e, n, a) {
                var r = t(e || "00:00", "HH:mm"),
                    i = t(n || "23:00", "HH:mm"),
                    l = 60 / a * 30;
                return (i.diff(r, "hours") + 1) * l + 2
            }
            return {
                getWeekDayNames: c,
                getYearView: v,
                getMonthView: m,
                getWeekView: u,
                getDayView: f,
                getWeekViewWithTimes: p,
                getDayViewHeight: w,
                adjustEndDateFromStartDiff: i,
                formatDate: r,
                eventIsInPeriod: l
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a = n(1);
        a.module("mwl.calendar").factory("calendarTitle", ["moment", "calendarConfig", "calendarHelper", function(e, t, n) {
            function a(e) {
                return n.formatDate(e, t.titleFormats.day)
            }

            function r(n) {
                var a = t.titleFormats.week;
                return a.replace("{week}", e(n).week()).replace("{year}", e(n).format("YYYY"))
            }

            function i(e) {
                return n.formatDate(e, t.titleFormats.month)
            }

            function l(e) {
                return n.formatDate(e, t.titleFormats.year)
            }
            return {
                day: a,
                week: r,
                month: i,
                year: l
            }
        }])
    }, function(e, t, n) {
        "use strict";
        var a, r = n(1);
        try {
            a = n(38)
        } catch (i) {
            a = null
        }
        r.module("mwl.calendar").constant("interact", a)
    }, function(e, t, n) {
        "use strict";
        var a = n(1),
            r = n(37);
        a.module("mwl.calendar").constant("moment", r)
    }, function(e, t, n) {
        function a(e) {
            return n(r(e))
        }

        function r(e) {
            return i[e] || function() {
                throw new Error("Cannot find module '" + e + "'.")
            }()
        }
        var i = {
            "./mwlCalendar.js": 12,
            "./mwlCalendarDay.js": 13,
            "./mwlCalendarHourList.js": 14,
            "./mwlCalendarMonth.js": 15,
            "./mwlCalendarSlideBox.js": 16,
            "./mwlCalendarWeek.js": 17,
            "./mwlCalendarYear.js": 18,
            "./mwlCollapseFallback.js": 19,
            "./mwlDateModifier.js": 20,
            "./mwlDraggable.js": 21,
            "./mwlDroppable.js": 22,
            "./mwlElementDimensions.js": 23,
            "./mwlResizable.js": 24
        };
        a.keys = function() {
            return Object.keys(i)
        }, a.resolve = r, e.exports = a, a.id = 34
    }, function(e, t, n) {
        function a(e) {
            return n(r(e))
        }

        function r(e) {
            return i[e] || function() {
                throw new Error("Cannot find module '" + e + "'.")
            }()
        }
        var i = {
            "./calendarDate.js": 25,
            "./calendarLimitTo.js": 26,
            "./calendarTruncateEventTitle.js": 27
        };
        a.keys = function() {
            return Object.keys(i)
        }, a.resolve = r, e.exports = a, a.id = 35
    }, function(e, t, n) {
        function a(e) {
            return n(r(e))
        }

        function r(e) {
            return i[e] || function() {
                throw new Error("Cannot find module '" + e + "'.")
            }()
        }
        var i = {
            "./calendarConfig.js": 29,
            "./calendarHelper.js": 30,
            "./calendarTitle.js": 31,
            "./interact.js": 32,
            "./moment.js": 33
        };
        a.keys = function() {
            return Object.keys(i)
        }, a.resolve = r, e.exports = a, a.id = 36
    }, function(e, n) {
        e.exports = t
    }, function(e, t) {
        if ("undefined" == typeof n) {
            var a = new Error('Cannot find module "undefined"');
            throw a.code = "MODULE_NOT_FOUND", a
        }
        e.exports = n
    }])
});
//# sourceMappingURL=angular-bootstrap-calendar-tpls.min.js.map