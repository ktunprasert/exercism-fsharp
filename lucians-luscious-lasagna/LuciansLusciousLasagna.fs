module LuciansLusciousLasagna

// TODO: define the 'expectedMinutesInOven' binding
let expectedMinutesInOven = 40

// TODO: define the 'remainingMinutesInOven' function
let remainingMinutesInOven elapsed = expectedMinutesInOven - elapsed

// TODO: define the 'preparationTimeInMinutes' function
let preparationTimeInMinutes layers = layers * 2

// TODO: define the 'elapsedTimeInMinutes' function
let elapsedTimeInMinutes layers elapsed =
    (preparationTimeInMinutes layers) + elapsed
