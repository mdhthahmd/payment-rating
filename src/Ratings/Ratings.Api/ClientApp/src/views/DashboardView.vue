<script setup>
import { ref }  from "vue"
import axios from 'axios'
import FiveStarRating from '../components/FiveStarRating.vue'

let employers = ref({})

axios
  .get("api/dashboard")
  .then(response => employers.value = response.data)


</script>


<template>
    <div class="py-10">
      <header>
        <div class="mx-auto max-w-3xl lg:max-w-7xl px-4 sm:px-6 lg:px-8">
          <h1 class="text-3xl font-bold leading-tight tracking-tight text-gray-900">Dashboard</h1>
        </div>
      </header>
      <main>
        <div class="mx-auto max-w-3xl lg:max-w-7xl sm:px-6 lg:px-8">
          
          <!-- Content -->
          <div class="px-4 py-8 sm:px-0">

            <div>
                <h2 class="text-base font-semibold leading-6 text-gray-900">Heighest Ranking Employers</h2>
                <ul role="list" class="mt-3 grid grid-cols-1 gap-5 sm:grid-cols-2 sm:gap-6 lg:grid-cols-3">
                <li v-for="(employer, index) in employers.best" :key="index" class="col-span-1 flex rounded-md shadow-sm">
                    <div class="bg-green-400 flex w-16 flex-shrink-0 items-center justify-center rounded-l-md text-3xl font-bold text-white">{{ index + 1 }}</div>
                    <div class="flex flex-1 items-center justify-between truncate rounded-r-md border-b border-r border-t border-gray-200 bg-white">
                    <div class="flex-1 truncate px-4 py-2 text-sm">
                        <p class="font-medium text-gray-900 hover:text-gray-600">{{ employer.name }}</p>
                        <div class="flex items-center -mx-1 my-1">
                          <FiveStarRating :rating="employer.stars" />
                          <p class="text-gray-500">({{ employer.points }} points)</p>
                        </div>
                    </div>
                    
                    </div>
                </li>
                </ul>
            </div>
          </div>

          <div class="px-4 py-8 sm:px-0">
            <div>
                <h2 class="text-base font-semibold leading-6 text-gray-900">Lowest Ranking Employers</h2>
                <ul role="list" class="mt-3 grid grid-cols-1 gap-5 sm:grid-cols-2 sm:gap-6 lg:grid-cols-3">
                <li v-for="(worstEmployer, index) in employers.worst" :key="worstEmployer.id" class="col-span-1 flex rounded-md shadow-sm">
                    <div class="bg-red-400 flex w-16 flex-shrink-0 items-center justify-center rounded-l-md text-3xl font-bold text-white">{{ index + 1 }}</div>
                    <div class="flex flex-1 items-center justify-between truncate rounded-r-md border-b border-r border-t border-gray-200 bg-white">
                    <div class="flex-1 truncate px-4 py-2 text-sm">
                        <p class="font-medium text-gray-900 hover:text-gray-600">{{ worstEmployer.name }}</p>
                        <div class="flex items-center -mx-1 my-1">
                          <FiveStarRating :rating="worstEmployer.stars" />
                          <p class="text-gray-500">({{ worstEmployer.points }} points)</p>
                        </div>
                    </div>
                    
                    </div>
                </li>
                </ul>
            </div>
          </div>
          <!-- /End Content -->
          
        </div>
      </main>
    </div>
  </template>