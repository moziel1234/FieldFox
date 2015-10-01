function [ ret_object ] = combineObjectToOne(in_obj )
%COMBINEOBJECTTOONE Summary of this function goes here
%   Detailed explanation goes here

    %Fisrt scale the level to 0 and max to one
    L = length(in_obj.amp_db(:,1));
    amp = zeros(size(in_obj));
    phs = zeros(size(in_obj));
    for freq_ind=1:1:length(in_obj.freqs)
       temp = smooth(in_obj.amp_db(1:L,freq_ind)-mean(in_obj.amp_db(1:L,freq_ind)));
       amp(1:L,freq_ind) = (temp)./max(abs(temp));
       
       temp2 = abs(in_obj.phase_deg(1:L,freq_ind)-mean(in_obj.phase_deg(1:L,freq_ind)));
       phs(1:L,freq_ind) = (temp2)./max(abs(temp2));
    end
    ret_object.amp = reshape(amp,1,[]);
    ret_object.phs = reshape(phs,1,[]);
    figure; plot(ret_object.amp);
    figure; plot(ret_object.phs);
end

