prompt = '>'

puts "Enter a string to permutate:"
print prompt

string = gets.chomp()

permarray = string.chars.to_a.permutation.map(&:join).uniq

#

permarray.delete_if do |s|
  s =~ /(.*)[b-df-hj-np-tv-xzB-DF-HJ-NP-TV-XZ]{4,}/
end

permarray.delete_if do |s|
  s =~ /(.*)[aeiouyAEIOUY]{4,}/
end

$stdout.reopen("test.txt", "w")

permarray.each do |element|
  puts element
end
