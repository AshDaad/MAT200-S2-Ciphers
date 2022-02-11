# Code for ciphering

# Create character matrix from text
def matrixfy(text, len)
    desired = (text.size.to_f / len).ceil * len
    text.downcase.ljust(desired, "x").chars.each_slice(len).to_a
end

# Convert to matrix, sort columns according to corresponding key characters
def cipher(message, key)
  m = matrixfy(message, key.size).unshift(key.chars).transpose
  m.sort_by! { |column| column.first }
  m.each { |column| column.shift }
  m.map(&:join).join(' ')
end

# Code for deciphering

# Pack array as hash where keys are elements and values are indexes
def pack_as_hash(arr)
  result = {}
  arr.each_with_index { |e, i| result[e] = i }
  result
end

# Return array representing ordering
def order(str)
  chars = str.chars
  new_order = pack_as_hash(chars.sort)
  chars.each_with_object([]) { |chr, result| result << new_order[chr] }
end

# Reorder columns according to key
def decipher(message, key)
  m = message.split(' ').map!(&:chars)
  o = order(key)
  r = Array.new(key.size)
  o.each_with_index { |e, i| r[i] = m[e] }
  r.transpose.map(&:join).join
end

# Bruteforce and output results - due to how keys are used,
# we just use permutations of a sequence of numbers from 1 to the key
# length - we can find the key size just looking at the ciphered message
def brute_force(message)
  len = message.split(' ').size
  keys = ('1'..len.to_s).to_a.permutation.map(&:join)
  keys.each_with_object({}) { |k, result| result[k] = decipher(message, k) }
end

# Alternative way to cipher - meant to show that ciphering and deciphering
# this way is pretty much opposite operations
def alt_cipher(message, key)
  m = matrixfy(message, key.size).unshift(key.chars).transpose
  o = order(key)
  r = Array.new(key.size)
  o.each_with_index { |e, i| r[e] = m[i] }
  m.map(&:join).join(' ')
end
