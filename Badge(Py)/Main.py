from sys import stdin

def check_student(mapping, startStudent):
    students = [False] * len(mapping)
    i = startStudent

    while not students[i]:
        students[i] = True
        i = mapping[i]
    
    return i + 1

# Read inputs and set the data
students = []

stdin.readline()
for line in stdin:
    if not line.strip():
        break

    splitted = line.strip().split(" ")
    if len(splitted) > 0:
        for item in splitted:
            students.append(int(item) - 1)

result = [None] * len(students)

# Calculate
i = 0
for student in students:
    result[i] = str(check_student(students, i))
    i += 1

separator = " "
print(separator.join(result))