<script setup>
import { ref } from 'vue'
import axios from 'axios'

const PagedEmployersList = ref()


axios
  .get("api/employers")
  .then(response => PagedEmployersList.value = response.data)

  console.log(PagedEmployersList.value)


</script>

<template>
  <div class="py-10">
    <header>
      <div class="mx-auto max-w-3xl lg:max-w-7xl px-4 sm:px-6 lg:px-8">
        <h1 class="text-3xl font-bold leading-tight tracking-tight text-gray-900">Employers</h1>
      </div>
    </header>
    <main>
      <div class="mx-auto max-w-3xl lg:max-w-7xl sm:px-6 lg:px-8">

        <!-- Content -->
        <div class="px-4 py-8 sm:px-0">

          <div class="sm:flex sm:items-center">
            <div class="sm:flex-auto">
              <h1 class="text-base font-semibold leading-6 text-gray-900">Employers List</h1>
              <p class="mt-2 text-sm text-gray-700">A list of all the employers in the system.</p>
            </div>

          </div>
          <div class="mt-8 flow-root">
            <div class="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
              <div class="inline-block min-w-full py-2 align-middle sm:px-6 lg:px-8">
                <table class="min-w-full divide-y divide-gray-300">
                  <thead>
                    <tr>
                      <th scope="col"
                        class="py-3 pl-4 pr-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500 sm:pl-0">
                        #</th>
                      <th scope="col"
                        class="px-3 py-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500">Name</th>
                      <th scope="col"
                        class="px-3 py-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500">Points</th>
                      <th scope="col"
                        class="px-3 py-3 text-left text-xs font-medium uppercase tracking-wide text-gray-500">Stars</th>
                    </tr>
                  </thead>
                  <tbody class="divide-y divide-gray-200 bg-white">
                    <tr v-for="employer in PagedEmployersList.data" :key="employer.id">
                      <td class="whitespace-nowrap py-4 pl-4 pr-3 text-sm font-medium text-gray-900 sm:pl-0">{{
                        employer.id }}</td>
                      <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-500">{{ employer.name }}</td>
                      <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-500">{{ employer.points }}</td>
                      <td class="whitespace-nowrap px-3 py-4 text-sm text-gray-500">{{ employer.stars }}</td>

                    </tr>
                  </tbody>
                </table>
              </div>
            </div>
          </div>


          <nav class="flex items-center justify-between border-t border-gray-200 bg-white py-3" aria-label="Pagination">
            <div class="hidden sm:block">
              <p class="text-sm text-gray-700">
                Showing
                {{ ' ' }}
                <span class="font-medium"> 1</span>
                {{ ' ' }}
                to
                {{ ' ' }}
                <span class="font-medium">10</span>
                {{ ' ' }}
                of
                {{ ' ' }}
                <span class="font-medium">{{ PagedEmployersList.totalRecords }}</span>
                {{ ' ' }}
                results
              </p>
            </div>
            <div class="flex flex-1 justify-between sm:justify-end">
              <a href="#"  v-show="PagedEmployersList.previousPage"
                class="relative inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Previous</a>
              <a href="#"  v-show="PagedEmployersList.nextPage"
                class="relative ml-3 inline-flex items-center rounded-md bg-white px-3 py-2 text-sm font-semibold text-gray-900 ring-1 ring-inset ring-gray-300 hover:bg-gray-50 focus-visible:outline-offset-0">Next</a>
            </div>
          </nav>
        </div>
      <!-- /End Content -->

    </div>
  </main>
</div></template>