from sys import stdin

# Define the main class for calculations
class Calculator:
    __slots__ = ['_threshold', '_friendship', '_people', '_group', '_group_friendship']

    def __init__(self, people, threshold):
        self._friendship = 0
        self._group = []
        self._group_friendship = 0

        self._threshold = threshold
        self._people = people

    def _reduce_group(self):
        if not self._check(self._group[-1][0], self._group[0][0], self._threshold):
            self._group_friendship -= self._group[0][1]
            self._group.pop(0)
        else:
            self._friendship = self._friendship if self._friendship > self._group_friendship else self._group_friendship
            return False
        return True

    def _check(self, a, b, t):
        return (a - b) < t

    def calc(self):
        while len(self._people) != 0:
            topFriend = self._people.pop(-1)

            self._group.append(topFriend)
            self._group_friendship += topFriend[1]

            while len(self._group) > 0 and self._reduce_group():
                pass

        return self._friendship

# Read inputs and set the data
friends_threshold = 0
friends_array = []

for line in stdin:
    if not line.strip():
        break
        
    splitted = line.strip().split(" ")
    if len(splitted) > 0:
        if friends_threshold > 0:
            friends_array.append((int(splitted[0]), int(splitted[1])))
        else:
            friends_threshold = int(splitted[1])

# Sort
friends_array.sort(key = lambda a: a[0], reverse = True)

# Calc
if friends_threshold > friends_array[0][0]:
    result = sum(map(lambda x: x[1], friends_array))
    print(result)
else:
    calcObject = Calculator(friends_array, friends_threshold)
    print(calcObject.calc())
