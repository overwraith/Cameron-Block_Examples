#Author: Cameron Block 
#Class: CIS 337 Web Scripting
#File: SecondSmallest.html
#Purpose: Create a ruby script that finds the second 
#			smallest in an array of numbers. 

#create the array for storing values
list = Array.new

#get values from the keyboard for the list
#Ctrl-Z to exit
puts "Please input as many numbers as you want. "
puts "Press Ctrl+Z to preform the SecondSmallest operation. "

index = 0
tmp = 1
while(tmp = gets)
	list[index] = tmp.to_i
	index += 1
end

#load hash values
hash = Hash.new
index = 0
list.each{|value| 
	hash[index.to_s] = value
	index += 1
}

#sort the hash, returns an array
sortedHash = hash.sort_by{|k,v| v }

if list.length >= 1
	#second smallest value will be hash[1]
	puts "index and value: " + sortedHash[1].to_s
else
	puts "The array you entered was not big enough. "
end

puts "Press any key to continue..."
tmp = gets